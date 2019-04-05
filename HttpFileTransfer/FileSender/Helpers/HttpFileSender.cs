using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileSender.Helpers
{
    internal class HttpFileSender
    {
        private static HttpClient _httpClient;

        internal HttpFileSender(string siteUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(siteUrl);
        }


        internal void Send(string url, NameValueCollection postCollection, string fileName, byte[] fileContent)
        {
            using (var content = new MultipartFormDataContent())
            {
                //----- 加入檔案內容 -----
                var mimeType = MimeMapping.GetMimeMapping(fileName);
                ByteArrayContent byteContent = new ByteArrayContent(fileContent);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType);

                content.Add(byteContent, "File", fileName);
                //----- 加入檔案內容 -----



                //----- 加入 post 文字 -----
                foreach (var key in postCollection.AllKeys)
                {
                    var value = postCollection[key];
                    content.Add(new StringContent(value), key);
                }
                //----- 加入 post 文字 -----


                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                var response = _httpClient.PostAsync(url, content).Result;
                response.EnsureSuccessStatusCode();

                var result = response.Content.ReadAsStringAsync().Result;
            }
        }
    }

}
