using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace NganHangTracNghiem.DLL
{
    public class ExtractZip //extract file zip.
    {
        //get file is docx
        public ZipArchiveEntry GetDocFile(string zipPath)
        {
            ZipArchive archive = ZipFile.OpenRead(zipPath);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))//get file docx
                {
                  
                    return entry;
                }
            }
            return null;
        }
        //count file is doc
        public int CountFileDocx(string zipPath)
        {
            ZipArchive archive = ZipFile.OpenRead(zipPath);//read file zip
            int NumberDocx = 0;
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))//if entry is file docx increase  NumberDocx
                {
                    NumberDocx++;
                }
            }
            return NumberDocx;
        }
        //get file by name
        public ZipArchiveEntry GetFileByName(string zipPath,string name)
        {
            ZipArchive archive = ZipFile.OpenRead(zipPath);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.Name.Contains(name))//get file docx
                {
                    return entry;
                }
            }
            archive.Dispose();
            return null;
        }
    }
}
