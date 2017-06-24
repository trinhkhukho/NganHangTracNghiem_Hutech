using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NganHangTracNghiem.DLL
{
     public class ReadXML
    {
        public string ReadXML_Host(string FileFath, string Text)
        {
            string content="";
            XmlDocument doc = new XmlDocument();
            doc.Load(FileFath);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if(node.Name.Contains(Text))
               {
                    content = node.InnerText;
                }
                
            }
            return content;
        }
    }
}
