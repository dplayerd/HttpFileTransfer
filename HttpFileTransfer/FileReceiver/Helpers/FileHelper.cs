using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace FileReceiver.Helpers
{
    public class FileHelper
    {
        /// <summary> 存檔 </summary>
        /// <param name="saveFilePath">存檔路徑</param>
        /// <param name="stream"> 檔案內容 </param>
        public static void Save(string saveFilePath, MemoryStream stream)
        {
            File.WriteAllBytes(saveFilePath, stream.ToArray());
        }


        /// <summary> 搬移檔案 </summary>
        /// <param name="sourcePath"> 來源路徑 </param>
        /// <param name="toPath"> 目標路徑 </param>
        /// <param name="willCover"> 是否允許覆蓋 </param>
        public static void Move(string sourcePath, string toPath, bool willCover)
        {
            if (willCover && File.Exists(toPath))
                File.Delete(toPath);

            File.Move(sourcePath, toPath);
        }


        /// <summary> 建立資料夾 </summary>
        /// <param name="pathes"></param>
        public static void CreateDirectory(params string[] pathes)
        {
            foreach (string path in pathes)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
        }
    }
}