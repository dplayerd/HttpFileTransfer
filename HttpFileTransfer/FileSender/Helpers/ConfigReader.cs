using FileSender.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Helpers
{
    internal class ConfigReader
    {
        internal static FileSenderConfig GetConfig()
        {
            FileSenderConfig retObj = new FileSenderConfig();

            retObj.FileFolderPath = ConfigurationManager.AppSettings["sourceFolder"];
            retObj.Key = ConfigurationManager.AppSettings["key"];
            retObj.ApiUrl = ConfigurationManager.AppSettings["destUrl"];
            retObj.SiteUrl = ConfigurationManager.AppSettings["siteUrl"];

            return retObj;
        }
    }
}
