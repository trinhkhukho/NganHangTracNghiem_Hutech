﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using NganHangTracNghiem.Data;
using System.Web.Http.Description;
using System.IO.Compression;
using NganHangTracNghiem.DLL;
using System.Web.Http;
using NganHangTracNghiem.DDL;

namespace NganHangTracNghiem.Web.Controllers
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
            string filename = new FileInfo(file.FileName).Name;
            if (file.ContentLength > 0)
            {
                Guid id = new Guid();
                string PathName = path + id + filename;
                file.SaveAs(PathName);
                ReadFile rd = new ReadFile();
                string host;
                ReadXML rd_host = new ReadXML();
                string FilePathXML = System.Web.Hosting.HostingEnvironment.MapPath("/XML/") + "ClinicInfo.xml";
                host = rd_host.ReadXML_Host(FilePathXML, "host");
                string strExtexsion = Path.GetExtension(PathName).Trim();
                if (strExtexsion.ToLower() == ".docx")
                {
                    ListQuestion ls = rd.OpenWordprocessingDocumentReadonly(PathName, null, host,0);
                    File.Delete(PathName);
                    return Ok(ls);
                }
                if(strExtexsion.ToLower() == ".zip")
                {
                    ExtractZip rd_zip = new ExtractZip();
                    id = new Guid();
                    ZipArchiveEntry entry = rd_zip.GetFileByName(path + id+filename, ".docx");
                    entry.ExtractToFile(path +id+ entry.Name, true);
                    ListQuestion ls = rd.OpenWordprocessingDocumentReadonly(path + id + entry.Name, PathName, host,0);
                    
                    //File.Delete(PathName);
                    return Ok(ls);
                }
                
            }
            return InternalServerError();
        }
    }
}
