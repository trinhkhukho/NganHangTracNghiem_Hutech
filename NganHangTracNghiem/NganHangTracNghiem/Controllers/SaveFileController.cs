using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NganHangTracNghiem.Controllers
{
    public class SaveFileController : ApiController
    {
        [HttpPost]
        [Route("api/SaveFile_Img")]
        public Task<HttpResponseMessage> SaveFile_Img()
        {
            List<string> savedFilePath = new List<string>();
            string rootPath = HttpContext.Current.Server.MapPath("~/Img");
            var provider = new MultipartFileStreamProvider(rootPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }
                foreach (MultipartFileData item in provider.FileData)
                {
                    try
                    {
                        string Name = item.Headers.ContentDisposition.FileName;
                        File.Move(item.LocalFileName, Path.Combine(rootPath, Name));

                        Uri BaseUri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                        string fileRelativePath = "~/Img/" + Name;
                        Uri FileFullFath = new Uri(BaseUri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                        savedFilePath.Add(FileFullFath.ToString());
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.Created, savedFilePath);
            });
            return task;
        }
        [HttpPost]
        [Route("api/SaveFile_Audio")]
        public Task<HttpResponseMessage> SaveFile_Audio()
        {
            List<string> savedFilePath = new List<string>();
            string rootPath = HttpContext.Current.Server.MapPath("~/Audio");
            var provider = new MultipartFileStreamProvider(rootPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }
                foreach (MultipartFileData item in provider.FileData)
                {
                    try
                    {
                        string Name = item.Headers.ContentDisposition.FileName;
                        File.Move(item.LocalFileName, Path.Combine(rootPath, Name));

                        Uri BaseUri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                        string fileRelativePath = "~/Img/" + Name;
                        Uri FileFullFath = new Uri(BaseUri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                        savedFilePath.Add(FileFullFath.ToString());
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.Created, savedFilePath);
            });
            return task;
        }
    }
}
