using System;
using System.Collections.Generic;

namespace WebBrowser
{
    public class History
    {
        //----------------------------------------//
        //----------Fieds-------------------------//
        //----------------------------------------//
        private LinkedList<Page> tabHistory;
        private LinkedListNode<Page> current;

        public History()
        {
            tabHistory = new LinkedList<Page>();
            current = new LinkedListNode<Page>(null);
        }

        //----------------------------------------//
        //----------Methods-----------------------//
        //----------------------------------------//

        //create and add a new page to the history given an url
        //only adds it if it's not the current loaded page
        public bool addPage(string url)
        {
            Page s = new Page(url);
            if (current.Value != null && !(current.Value.url.Equals(url)))
            {
                tabHistory.AddAfter(current, s);
                current = current.Next;
                //resets tab history to only contain previous pages from the new current node
                //removes forward history
                while(!tabHistory.Last.Equals(current))
                {
                    tabHistory.RemoveLast();
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

        //checks if there is a previous node to go from the current one
        public bool canGoToPrevious()
        {
            return (current.Previous != null);
        }

        //checks if there is a next node to go from the current one
        public bool canGoToNext()
        {
            return (current.Next != null);
        }

        //sets the current node to the previous one and return the url associated with it
        public string goToPrevious()
        {
            if(canGoToPrevious())
            {
                current = current.Previous;
                return current.Value.url;
            }
            else
            {
                throw new Exception("No previous Page to go to Exception");
            }
        }

        //sets the current node to the next one and return the url associated with it
        public string goToNext()
        {
            if (canGoToNext())
            {
                current = current.Next;
                return current.Value.url;
            }
            else
            {
                throw new Exception("No next Page to go to Exception");
            }
        }
    }
}
