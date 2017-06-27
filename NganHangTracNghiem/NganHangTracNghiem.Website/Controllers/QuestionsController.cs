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

namespace NganHangTracNghiem.Website.Controllers
{
    public class QuestionsController : ApiController
    {
        //thêm mới câu hỏi đơn
        [HttpPost]
        [Route("api/Question/add")]
        public IHttpActionResult Add(ModelQuestions CauHoi)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                QuestionsSevices sevices = new QuestionsSevices();
                int kq = sevices.CreateQuestion(CauHoi, host);
                return Ok(kq);
            }
            catch
            {
                return InternalServerError();
            }
        }
        //thêm mới câu hỏi nhóm
        [HttpPost]
        [Route("api/Question/addGroupParent")]
        public IHttpActionResult addGroupParent(ModelQuestionsGroupParent CauHoi)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                QuestionsSevices sevices = new QuestionsSevices();
                long kq = sevices.CreateQuestionGroupParent(CauHoi, host);
                return Ok(kq);
            }
            catch
            {
                return InternalServerError();
            }
        }
        //thêm mới câu hỏi con trong câu hỏi nhóm
        [HttpPost]
        [Route("api/Question/addGroupChil")]
        public IHttpActionResult addGroupChil(ModelQuestionsGroupChil CauHoi)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                QuestionsSevices sevices = new QuestionsSevices();
                long kq = sevices.CreateQuestionGroupChil(CauHoi, host);
                return Ok(kq);
            }
            catch
            {
                return InternalServerError();
            }
        }
        //lấy thông tin câu hỏi theo user
        //thêm mới câu hỏi đơn
        [HttpGet]
        [Route("api/Question/get")]
        public HttpResponseMessage getQuestion(ModelQuestions CauHoi)
        {
            HttpResponseMessage response = null;
            ReadXML rd_host = new ReadXML();
            string host;
            string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
            host = rd_host.ReadXML_Host(FilePathXML, "host");
            QuestionsSevices sevices = new QuestionsSevices();
            response = sevices.GetQuestion(10001, host);
            return response;
        }
        //chỉnh sửa câu hỏi
        [HttpPost]
        [Route("api/Question/edit")]
        public IHttpActionResult Edit(ModelQuestionsEdit CauHoi)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                QuestionsSevices sevices = new QuestionsSevices();
                int kq = sevices.EditQuestion(CauHoi, host);
                return Ok(kq);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/Question/delete")]
        public IHttpActionResult Delete(ModelQuestionsDelete CauHoi)
        {
            try
            {
                ReadXML rd_host = new ReadXML();
                string host;
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                QuestionsSevices sevices = new QuestionsSevices();
                int kq = sevices.deleteQuestion(CauHoi, host);
                return Ok(kq);
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
