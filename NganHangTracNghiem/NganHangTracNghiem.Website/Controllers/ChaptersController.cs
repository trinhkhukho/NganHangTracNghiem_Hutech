using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Data;
using NganHangTracNghiem.DLL;
using System.Net.Http.Headers;

namespace NganHangTracNghiem.Website.Controllers
{
    public class ChaptersController : ApiController
    {
        [HttpPost]
        [Route("api/Chapters/delete")]
        public IHttpActionResult ChaptersDelete(Chapters c)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(host);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var reponse = client.DeleteAsync(host + "api/Chapters/" + c.ID).Result;
                if (reponse.IsSuccessStatusCode)
                {
                    return Ok(1);
                }
                return Ok(0);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
