using FileSender.Helpers;
using System;
using System.Configuration;
using System.Diagnostics;

namespace FileSender
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigReader.GetConfig();

            var uploadList = FileHelper.GetUploadFiles();


            Console.WriteLine(" Start sending file to " + config.ApiUrl);

            // Send a http post per file
            HttpFileSender sender = new HttpFileSender(config.SiteUrl);

            foreach (var item in uploadList)
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    DateTime cDate = DateTime.Now;

                    Console.WriteLine(" Sending " + item.FileName);
                    sender.Send(config.ApiUrl, item.PostData, item.FileName, item.FileContent);

                    var totalTime = (DateTime.Now - cDate).TotalMilliseconds;
                    Console.WriteLine($" Send {item.FileName} completed. Cost {totalTime} ms");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }


            Console.WriteLine(" All file Completed. ");

#if (DEBUG)
            Console.ReadLine();
#endif
        }
    }
}
