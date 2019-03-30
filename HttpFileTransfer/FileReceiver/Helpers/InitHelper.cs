using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReceiver.Helpers
{
    public class InitHelper
    {
        /// <summary> 執行初始化 </summary>
        public static void Init()
        {
            // 建立資料夾
            string tempFolder = ConfigHelper.TempFolderPath;
            string uploadFolder = ConfigHelper.SaveToFolderPath;
            FileHelper.CreateDirectory(tempFolder, uploadFolder);
        }
    }
}