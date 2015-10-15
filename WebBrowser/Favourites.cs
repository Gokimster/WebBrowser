using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class Favourites:PersistenceMgr
    {
        private Dictionary<int, Favourite> favs;

        public Favourites()
        {
            initXML("Favourtites");

            favs = new Dictionary<int, Favourite>();
            foreach(var f in xmlElem.Elements())
            {
                favs[int.Parse(f.Element("Id").Value)] = new Favourite(f.Element("Url").Value, f.Element("Name").Value);
            }
        }

        public void addFavourite(string url, string name) {
            //using a random int as the key because we are also using this as 
            Random rnd = new Random();
            int i;
            do {
                i = rnd.Next();
            } while (favs.ContainsKey(i));
            Favourite temp = new Favourite(url, name);
            favs.Add(i, temp);
            addFavToFile(i, temp);
        }

        public void removeFavourite(Favourite f)
        {
            foreach(var fav in favs.Where(kvp => kvp.Value.Equals(f)).ToList())
            {
                favs.Remove(fav.Key);
                var favourites = from el in xmlElem.Elements("Favourite")
                                where (int)el.Element("Id") == fav.Key
                                select el;
                foreach(XElement xel in favourites)
                {
                    xel.Remove();
                }
            }
            xmlElem.Save(fileName);
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

        public Favourite this[int index]
        {
            get
            {
                if (!favs.ContainsKey(index))
                {
                    return null;
                }
                else
                {
                    return favs[index];
                }
            }
            //no set method because we want to use the addFavourite() method
            //to generate the id which is also the index
        }
    }

    
}
