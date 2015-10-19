using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class History:PersistenceMgr
    {
        private LinkedList<Page> tabHistory;
        private LinkedListNode<Page> current;
        private static Stack<Page> browserHistory;

        public History()
        {
            initXML("History");
            tabHistory = new LinkedList<Page>();
            if (browserHistory == null)
            {
                browserHistory = new Stack<Page>();
                foreach (var f in xmlElem.Elements())
                {
                    browserHistory.Push(new Page(f.Element("Url").Value));
                }
            }
            current = new LinkedListNode<Page>(null);
        }

        public void addPage(string url)
        {
            Page s = new Page(url);
            if (current.Value != null && !(current.Value.url.Equals(url)))
            {
                tabHistory.AddBefore(current, s);
                current = current.Previous;
                //resets tab history to only contain previous pages from the new current node
                //removes forward history
                while(!tabHistory.First.Equals(current))
                {
                    tabHistory.RemoveFirst();
                }
                addToBrowserHistory(s);
            }
            else
            {
                if(current.Value == null)
                {
                    tabHistory.AddFirst(s);
                    current = tabHistory.First;
                    addToBrowserHistory(s);
                }
            }
        }

        public void addToBrowserHistory(Page p)
        {
            browserHistory.Push(p);
            addPageToHistory(p);
        }

        private void addPageToHistory(Page p)
        {
            xmlElem.Add(new XElement("Page", new XElement("Url", p.url)));
            xmlElem.Save(fileName);
        }

        public bool canGoToPrevious()
        {
            //checks the next element because previous pages are
            //thowards the tail of the linked list
            return (current.Next != null);
        }

        public bool canGoToNext()
        {
            //checks previous element because next/forward pages are
            //thowards the head of the linked list
            return (current.Previous != null);
        }

        public string goToPrevious()
        {
            if(canGoToPrevious())
            {
                current = current.Next;
                return current.Value.url;
            }
            else
            {
                throw new Exception("No previous Page to go to Exception");
            }
        }

        public string goToNext()
        {
            if (canGoToNext())
            {
                current = current.Previous;
                return current.Value.url;
            }
            else
            {
                throw new Exception("No next Page to go to Exception");
            }
        }
    }
}
