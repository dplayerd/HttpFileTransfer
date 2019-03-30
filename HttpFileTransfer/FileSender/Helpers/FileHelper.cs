using FileSender.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Helpers
{
    public class FileHelper
    {
        /// <summary> read all file from folder </summary>
        /// <returns></returns>
        public static IEnumerable<UploadFileInfo> GetUploadFiles()
        {
            string sourceFolder = ConfigurationManager.AppSettings["sourceFolder"];

            var filePathes = Directory.GetFiles(sourceFolder);

            foreach (var filePath in filePathes)
            {
                var obj = new UploadFileInfo();

                obj.FileName = Path.GetFileName(filePath);
                obj.FileContent = File.ReadAllBytes(filePath);

                // this key will be contained in reply
                obj.PostData.Add("Key", Guid.NewGuid().ToString());

                yield return obj;
            }
        }
    }
}
