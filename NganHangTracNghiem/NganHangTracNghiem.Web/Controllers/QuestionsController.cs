using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using NganHangTracNghiem.DDL;
using NganHangTracNghiem.DLL;
using NganHangTracNghiem.Data;

namespace NganHangTracNghiem.Web.Controllers
{
    [RoutePrefix("api/Question")]
    public class QuestionsController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ModelQuestions CauHoi)
        {
            HttpResponseMessage response = null;
            ReadXML rd_host = new ReadXML();
            string host;
            string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML") + "ClinicInfo.xml";
            host = rd_host.ReadXML_Host(FilePathXML, "host");
            QuestionsSevices a = new QuestionsSevices();
            var aaa = a.CreateQuestion(CauHoi, host);
            //    string path = System.Web.Hosting.HostingEnvironment.MapPath("/File/");
            //    System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //    System.Web.HttpPostedFile file = files[0];
            //    string filename = new FileInfo(file.FileName).Name;
            //    if (file.ContentLength > 0)
            //    {
            //        Guid id = new Guid();
            //        file.SaveAs(path + filename);
            //        ReadFile rd = new ReadFile();
            //        rd.OpenWordprocessingDocumentReadonly(path + filename);
            //    }
            return response;

        }
        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage UploadImage()
        {
            HttpResponseMessage response = null;
            string path = System.Web.Hosting.HostingEnvironment.MapPath("/File/");
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            System.Web.HttpPostedFile file = files[0];
            string filename = new FileInfo(file.FileName).Name;
            if (file.ContentLength > 0)
            {

            }
            return response;
        }
    }
}
