using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.DDL;
using NganHangTracNghiem.Data;
using System.Web.Http.Description;
using NganHangTracNghiem.DLL;
using System.IO.Compression;

namespace NganHangTracNghiem.Website.Controllers
{
    public class ReadFileController : ApiController
    {
        [HttpPost]
        [Route("api/FileUpload")]
        [ResponseType(typeof(ListQuestion))]
        public IHttpActionResult UpLoad()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("/File/");
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            System.Web.HttpPostedFile file = files[0];
            string chapterids=System.Web.HttpContext.Current.Request.Form.ToString().Remove(0,10);
            int chapterid = int.Parse(chapterids);
            string filename = new FileInfo(file.FileName).Name;
            if (file.ContentLength > 0)
            {
                Guid id = new Guid();
                string PathName = path + id + filename;
                file.SaveAs(PathName);
                ReadFile rd = new ReadFile();
                string host;
                ReadXML rd_host = new ReadXML();
              
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/Scripts/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                string strExtexsion = Path.GetExtension(PathName).Trim();
                if (strExtexsion.ToLower() == ".docx")
                {
                    ListQuestion ls = rd.OpenWordprocessingDocumentReadonly(PathName, null, host, chapterid);
                    File.Delete(PathName);
                    return Ok(ls);
                }
                if(strExtexsion.ToLower() == ".zip")
                {
                    ExtractZip rd_zip = new ExtractZip();
                    id = new Guid();
                    ZipArchiveEntry entry = rd_zip.GetFileByName(path + id+filename, ".docx");
                    entry.ExtractToFile(path +id+ entry.Name, true);
                    ListQuestion ls = rd.OpenWordprocessingDocumentReadonly(path + id + entry.Name, PathName, host, chapterid);
                    
                    //File.Delete(PathName);
                    return Ok(ls);
                }
                
            }
            return InternalServerError();
        }
    }
}
