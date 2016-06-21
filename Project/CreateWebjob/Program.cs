using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateWebjob
{
    class Program
    {
       
        static void Main(string[] args)
        {            
            string _webjobName = "test_webjob";
            bool _status = create(_webjobName).Result;
        }
        public static async Task<bool> create(string webJobName)
        {           
            //have to provide here with publishing userName and Password of  your website
            string _PunlishingUserName = "$UserName";
            string _PublishingPassword = "Password";

            var _bytesArray=ReadZipFilebyPath(@"Zip_File\Web_host.zip");

            using (var client = new HttpClient())
            {
                var fileContent = new ByteArrayContent(_bytesArray);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"{webJobName}.zip"
                };
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _PunlishingUserName, _PublishingPassword))));
                //If you want delete scheduled or ondemant webjob use api/triggeredwebjobs/ in the Url
                //for continous webjob use api/continuouswebjobs/ in the Url 
                var response = await client.PutAsync("https://{YourWebsite}.scm.azurewebsites.net/api/continuouswebjobs/" + webJobName+"/", fileContent);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
        }

        private static byte[] ReadZipFilebyPath(string _Path)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory+ _Path;
            return File.ReadAllBytes(path);
        } 
    }
}
