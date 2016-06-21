using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DeleteWebJobByName
{
    class Program
    {

        static void Main(string[] args)
        {
            bool _status = delete("test_webjob").Result;
        }


        public static async Task<bool> delete(string webJobName)
        {
            //have to provide here with publishing userName and Password of  your website
            string _PunlishingUserName = "$UserName";
            string _PublishingPassword = "Password";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _PunlishingUserName, _PublishingPassword))));
                //you have to set you website properly
                //If you want delete scheduled or ondemant webjob use api/triggeredwebjobs/ in the Url
                //for continous webjob use api/continuouswebjobs/ in the Url 
                var response = await client.DeleteAsync("https://{YourWebsite}.scm.azurewebsites.net/api/continuouswebjobs/" + webJobName).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();               
                return response.IsSuccessStatusCode;
            }
        }


    }
}
