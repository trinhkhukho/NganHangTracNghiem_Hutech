using NganHangTracNghiem.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace NganHangTracNghiem.Website.Controllers
{
    public class DecentralizationController : ApiController
    {
        public IHttpActionResult GetDecentralization(int id)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(host + "api/GetUserRole_UserId/" + id);
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                httpWebRequest.Accept = "text/json";
                httpWebRequest = (HttpWebRequest)WebRequest.Create(host + "api/GetUserRole_UserId/" + id);
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(host);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var reponse = client.GetAsync(host + "api/GetUserRole_UserId/" + id).Result;
                if (reponse.IsSuccessStatusCode)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                    return Ok(sr.ReadToEnd().Trim());
                }
                response.Close();
                return Ok(0);
            }
            catch
            {
                return Ok(-1);
            }
        }
    }
}
