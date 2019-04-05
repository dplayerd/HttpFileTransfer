using FileSender.Helpers;
using System.Configuration;

namespace FileSender
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string apiUrl = ConfigurationManager.AppSettings["destUrl"];
            string siteUrl = ConfigurationManager.AppSettings["siteUrl"];

            var uploadList = FileHelper.GetUploadFiles();


            // Send a http post per file
            HttpFileSender sender = new HttpFileSender(siteUrl);

            foreach (var item in uploadList)
            {
                sender.Send(apiUrl, item.PostData, item.FileName, item.FileContent);
            }
        }
    }
}
