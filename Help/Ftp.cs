using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantisbt.Help
{
    public class Ftp
    {
        private static readonly string originalConfig = "config_inc.php";
        private static readonly string backupConfig = "config_inc_backup.php";

        public static void BackupConfigFile()
        {
            FtpRenameFile(originalConfig, backupConfig);
            UploadFileFtp();
        }

        public static void RestoreConfigFile()
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create($"ftp://127.0.0.1/config/{originalConfig}");
            ftpRequest.Credentials = new NetworkCredential("root", "");
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

            using (var response = (FtpWebResponse) ftpRequest.GetResponse())
            {
                if (response.StatusCode != FtpStatusCode.FileActionOK)
                    throw new Exception(response.StatusDescription);
            }


            FtpRenameFile(backupConfig, originalConfig);
        }

        private static void FtpRenameFile(string fileName, string newFileName)
        {
            var ftpRequest = (FtpWebRequest)WebRequest.Create(string.Format("ftp://127.0.0.1/config/{0}", fileName));
            ftpRequest.Credentials = new NetworkCredential("root", "");
            ftpRequest.Method = WebRequestMethods.Ftp.Rename;
            ftpRequest.RenameTo = $"/config/{newFileName}";

            using (var response = (FtpWebResponse)ftpRequest.GetResponse())
            {
                if (response.StatusCode != FtpStatusCode.FileActionOK)
                    throw new Exception(response.StatusDescription);
            }
        }

        private static void UploadFileFtp()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://127.0.0.1/config/{originalConfig}");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("root", "");
            byte[] fileContents;
            using (var sourceStream = new StreamReader(TestContext.CurrentContext.TestDirectory + "\\config_inc.php"))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != FtpStatusCode.ClosingData)
                    throw new Exception(response.StatusDescription);
            }
        }
    }
}
