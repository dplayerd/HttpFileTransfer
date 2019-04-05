using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using FileReceiver.Helpers;
using FileReceiver.Models;

namespace FileReceiver.Controllers
{
    [RoutePrefix("api/file")]
    public partial class FileController : ApiController
    {
        [HttpPost]
        [Route("UploadFormData")]
        public async Task<IHttpActionResult> UploadFormData()
        {
            if (!this.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            // 也可以考慮使用 MultipartMemoryStreamProvider
            var provider = new MultipartFormDataStreamProvider(ConfigHelper.TempFolderPath);

            try
            {
                await this.Request.Content.ReadAsMultipartAsync(provider);
                ReceivedFileCollection collection = new ReceivedFileCollection();


                // record the text info of post
                collection.Key = provider.FormData["Key"];


                // record the file info of post
                foreach (MultipartFileData fileData in provider.FileData)
                {
                    var filePath = fileData.Headers.ContentDisposition.FileName.Trim('\"');


                    // Add reply container
                    collection.Payloads.Add(new ReceivedFile() { ContentType = fileData.Headers.ContentType.MediaType, Name = filePath });


                    // Move file
                    string saveFileName = this.GetSaveFileName(filePath, collection.Key);


                    string sourceFilePath = fileData.LocalFileName;
                    string uploadFilePath = Path.Combine(ConfigHelper.SaveToFolderPath, saveFileName);

                    FileHelper.Move(sourceFilePath, uploadFilePath, true);
                }


                collection.IsAccepted = true;

                return this.Ok(collection);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message)
                });
            }
        }

        private string GetSaveFileName(string filePath, string key)
        {
            string fileExt = Path.GetExtension(filePath);
            string fileName = Path.GetFileName(filePath);
            
            string cDate = DateTime.Now.ToString("yyyyMMddHHmmss");

            string saveFileName =
                $"{Path.GetFileNameWithoutExtension(filePath)}_{key}_{cDate}{fileExt}";


            return saveFileName;
        }
    }
}