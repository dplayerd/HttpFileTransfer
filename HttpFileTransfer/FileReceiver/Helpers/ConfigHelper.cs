using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FileReceiver.Helpers
{
    public class ConfigHelper
    {
        #region "File"
        /// <summary> 暫存資料夾路徑 </summary>
        /// <returns></returns>
        internal static string TempFolderPath
        {
            get
            {
                string folder =
                    ConfigurationManager.AppSettings["tempFolder"];

                return
                    (folder == null)
                        ? string.Empty
                        : folder;
            }
        }

        /// <summary> 暫存資料夾路徑 </summary>
        /// <returns></returns>
        internal static string SaveToFolderPath
        {
            get
            {
                string folder =
                    ConfigurationManager.AppSettings["saveToFolder"];

                return
                    (folder == null)
                        ? string.Empty
                        : folder;
            }
        }
        #endregion


        #region "Connection String"
        private const string _connKey = "MainDB";

        /// <summary> 取得連線字串的名稱 </summary>
        /// <returns></returns>
        internal static string ConnectionStringKey
        {
            get
            {
                return ConfigHelper._connKey;
            }
        }


        /// <summary> 取得連線字串 </summary>
        /// <returns></returns>
        internal static string ConnectionString
        {
            get
            {
                var configObj =
                    ConfigurationManager.ConnectionStrings[ConfigHelper.ConnectionStringKey];

                return
                    (configObj == null)
                        ? string.Empty
                        : configObj.ConnectionString;
            }
        }
        #endregion
    }
}