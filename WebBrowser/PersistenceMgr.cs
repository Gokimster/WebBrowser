using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class PersistenceMgr
    {
        protected XElement xmlElem;
        protected string fileName;

        protected void createXMLDoc(string name)
        {
            XNamespace empNM = "urn:lst-emp:emp";

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement(empNM + name));

            // Save to Disk
            if (fileName != null)
            {
                xDoc.Save(fileName);
            }
            else
            {
                xDoc.Save("..\\..\\" + name + ".xml");
            }
        }

        protected XElement initXML(string name) 
        {
            fileName = "..\\..\\"+name+".xml";
            try
            {
                xmlElem = XElement.Load(fileName);
            }
            catch (FileNotFoundException e)
            {
                createXMLDoc(name);
                xmlElem = XElement.Load(fileName);
            }
            return xmlElem;
        }

    }
}
