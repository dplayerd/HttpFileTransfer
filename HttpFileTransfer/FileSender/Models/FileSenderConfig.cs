using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Models
{
    public class FileSenderConfig
    {
        public string SiteUrl { get; set; }
        public string ApiUrl { get; set; }
        public string Key { get; set; }
        public string FileFolderPath { get; set; }
    }
}
