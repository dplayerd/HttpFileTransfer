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
            var config = ConfigReader.GetConfig();

            if (!Directory.Exists(config.FileFolderPath))
                yield break;

            var filePathes = Directory.GetFiles(config.FileFolderPath);

            foreach (var filePath in filePathes)
            {
                var obj = new UploadFileInfo();

                obj.FileName = Path.GetFileName(filePath);
                obj.FileContent = File.ReadAllBytes(filePath);

                // this key will be contained in reply
                obj.PostData.Add("Key", config.Key);

                yield return obj;
            }
        }
    }
}
