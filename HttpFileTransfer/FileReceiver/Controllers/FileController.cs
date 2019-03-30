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


                // 取得 Post 上來的文字內容
                collection.Key = provider.FormData["Key"];


                // 取得 Post 上來的檔案內容
                foreach (MultipartFileData fileData in provider.FileData)
                {
                    var filePath = fileData.Headers.ContentDisposition.FileName.Trim('\"');


                    // 加入回傳用的元件
                    collection.Payloads.Add(new ReceivedFile() { ContentType = fileData.Headers.ContentType.MediaType, Name = filePath });
                    

                    // 搬移檔案
                    string saveFileName = Path.GetFileName(filePath);

                    string sourceFilePath = fileData.LocalFileName;
                    string uploadFilePath = Path.Combine(ConfigHelper.SaveToFolderPath, saveFileName);

                    
                    FileHelper.Move(sourceFilePath, uploadFilePath, true);
                }

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
    }
}