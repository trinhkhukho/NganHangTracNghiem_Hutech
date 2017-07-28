using System;
using System.IO;
using System.Web.Http;
using NganHangTracNghiem.DDL;
using System.IO.Compression;
using NganHangTracNghiem.DLL;

namespace NganHangTracNghiem.Web.Controllers
{
    public class ReadFileZipController : ApiController
    {
        
        [HttpPost]
        [Route("api/FileUploadZip")]
        public IHttpActionResult UpLoad()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("/File/");
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            System.Web.HttpPostedFile file = files[0];
            string filename = new FileInfo(file.FileName).Name;
            if (file.ContentLength > 0)
            {
                Guid id = new Guid();
                file.SaveAs(path + filename);
                ExtractZip rd_zip = new ExtractZip();
                ZipArchiveEntry entry= rd_zip.GetFileByName(path + filename,".docx");
                entry.ExtractToFile(path + entry.Name, true);
                ReadFile rd = new ReadFile();
                rd.OpenWordprocessingDocumentReadonly(path+entry.Name,path + filename,null,0);
            }
            return InternalServerError();
        }
    }
}
