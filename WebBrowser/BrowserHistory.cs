using System.Collections.Generic;
using System.Xml.Linq;

namespace WebBrowser
{
    public class BrowserHistory:PersistenceMgr
    {

        public Stack<Page> browserHistory { get; private set; }

        //loads browser history from file
        public BrowserHistory()
        {
            browserHistory = new Stack<Page>();
            initXML("History");
            foreach (var f in xmlElem.Elements())
            {
                browserHistory.Push(new Page(f.Element("Url").Value));
            }
        }

        //create a page and add it to browser history given an url
        public void addToBrowserHistory(string url)
        {
            Page p = new Page(url);
            browserHistory.Push(p);
            addPageToHistory(p);
        }

        //add a page to the XElement and save it to file
        private void addPageToHistory(Page p)
        {
            xmlElem.Add(new XElement("Page", new XElement("Url", p.url)));
            xmlElem.Save(fileName);
        }

        //remove all pages from browser history and reset the history file
        public void clearBrowserHistory()
        {
            createXMLDoc("History");
            browserHistory.Clear();
        }
    }
}
