using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class FavouritesMgr:PersistenceMgr
    {
        private Dictionary<int, Favourite> favs;

        public FavouritesMgr()
        {
            initXML("Favourtites");

            favs = new Dictionary<int, Favourite>();
            foreach(var f in xmlElem.Elements())
            {
                favs[int.Parse(f.Element("Id").Value)] = new Favourite(f.Element("Url").Value, f.Element("Name").Value);
            }
        }

        public void addFavourite(string url, string name) {
            Random rnd = new Random();
            int i;
            do {
                i = rnd.Next();
            } while (favs.ContainsKey(i));
            Favourite temp = new Favourite(url, name);
            addFavToFile(i, temp);
        }

        private void addFavToFile(int id, Favourite f)
        {
            xmlElem.Add(new XElement("Favourite", new XElement("Id", id), new XElement("Url", f.url), new XElement("Name", f.name)));
            xmlElem.Save(fileName);
        }

        public Dictionary<int, Favourite> getFavourites()
        {
            return favs;
        }
    }

    
}
