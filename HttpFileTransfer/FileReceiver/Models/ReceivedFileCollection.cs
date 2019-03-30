using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace FileReceiver.Models
{
    /// <summary> 已收到的檔案回應 </summary>
    public class ReceivedFileCollection
    {
        /// <summary> 收到的檔案 </summary>
        public List<ReceivedFile> Payloads { get; set; } = new List<ReceivedFile>();

        /// <summary> 辨識用文字 </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary> 是否已被接受 </summary>
        public bool IsAccepted { get; set; } 

        /// <summary> 檔案總數 </summary>
        public int TotalRecords { get { return (this.Payloads == null) ? 0 : this.Payloads.Count; } }

        /// <summary> 收到檔案的時間 </summary>
        public DateTime ReceiveTime { get; set; } = DateTime.Now;
    }
}