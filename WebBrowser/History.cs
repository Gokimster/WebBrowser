using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class History
    {
        private LinkedList<Page> tabHistory;
        private LinkedListNode<Page> current;

        public History()
        {
            tabHistory = new LinkedList<Page>();
            current = new LinkedListNode<Page>(null);
        }

        public bool addPage(string url)
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
                return true;
            }
            else
            {
                if(current.Value == null)
                {
                    tabHistory.AddFirst(s);
                    current = tabHistory.First;
                    return true;
                }
            }
            return false;
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
