using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class BrowserHistory:PersistenceMgr
    {

        public Stack<Page> browserHistory { get; private set; }

        public BrowserHistory()
        {
            browserHistory = new Stack<Page>();
            initXML("History");
            if (browserHistory == null)
            {
                browserHistory = new Stack<Page>();
                foreach (var f in xmlElem.Elements())
                {
                    browserHistory.Push(new Page(f.Element("Url").Value));
                }
            }
        }


        public void addToBrowserHistory(string url)
        {
            Page p = new Page(url);
            browserHistory.Push(p);
            addPageToHistory(p);
        }

        private void addPageToHistory(Page p)
        {
            xmlElem.Add(new XElement("Page", new XElement("Url", p.url)));
            xmlElem.Save(fileName);
        }

        public void clearBrowserHistory()
        {
            createXMLDoc("History");
            browserHistory.Clear();
        }
    }
}
