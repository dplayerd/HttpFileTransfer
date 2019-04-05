using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Models
{
    public class UploadFileInfo
    {
        public NameValueCollection PostData { get; set; } = new NameValueCollection();

        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
