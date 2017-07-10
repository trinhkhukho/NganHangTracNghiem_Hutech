using NganHangTracNghiem.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using NganHangTracNghiem.Data;

namespace NganHangTracNghiem.Website.Controllers
{
    public class FacultiesController : ApiController
    {

        [HttpPost]
        [Route("api/Faculties/delete")]
        public IHttpActionResult FacultiesDelete(Questions q)
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
                var reponse = client.DeleteAsync(host+ "api/Faculties/" + q.Id).Result;
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
