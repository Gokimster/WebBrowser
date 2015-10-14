using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    class HomePageMgr:PersistenceMgr
    {
        public HomePageMgr()
        {
            initXML("HomePage");
        }

        public void setHomePage(string url)
        {
            if (xmlElem.Elements().Count() == 0)
            {
                xmlElem.Add(new XElement("Page", new XElement("Url", url)));
            }
            else
            {
                xmlElem.Element("Page").SetElementValue("Url", url);
            }
            xmlElem.Save(fileName);
        }

        public string getHomePageUrl()
        {
            if (xmlElem.Elements().Count() == 0)
            {
                return null;
            }
            else
            {
                return xmlElem.Element("Page").Element("Url").Value;
            }
        }
    }
}
