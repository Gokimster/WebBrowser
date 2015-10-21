using System.Linq;
using System.Xml.Linq;

namespace WebBrowser
{
    public class HomePage:PersistenceMgr
    {
        public HomePage()
        {
            initXML("HomePage");
        }

        //sets the home page in the XElement and in the file if it exists, or creates it if it doesn't
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

        //return the ur of the home page or null if there is no page set
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
