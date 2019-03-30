using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileReceiver.Models
{
    /// <summary> 已接收的檔案 </summary>
    public class ReceivedFile
    {
        /// <summary> 檔案 MIME TYPE </summary>
        public string ContentType { get; set; }

        /// <summary> 檔案名稱 </summary>
        public string Name { get; set; }
    }
}