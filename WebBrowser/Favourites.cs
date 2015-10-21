using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WebBrowser
{
    public class Favourites:PersistenceMgr
    {
        //----------------------------------------//
        //----------Fieds-------------------------//
        //----------------------------------------//
        private Dictionary<int, Favourite> favs;

        public Favourites()
        {
            initXML("Favourites");

            favs = new Dictionary<int, Favourite>();
            foreach(var f in xmlElem.Elements())
            {
                favs[int.Parse(f.Element("Id").Value)] = new Favourite(f.Element("Url").Value, f.Element("Name").Value);
            }
        }

        //----------------------------------------//
        //----------Methods-----------------------//
        //----------------------------------------//

        //creates a new favourite given a url and a name and adds it to the dictionary and to file
        public void addFavourite(string url, string name) {
            //using a random int as the key because we are also using this as an id in the xml file
            Random rnd = new Random();
            int i;
            do {
                i = rnd.Next();
            } while (favs.ContainsKey(i));
            Favourite temp = new Favourite(url, name);
            favs.Add(i, temp);
            addFavToFile(i, temp);
        }

        //remove a favourite from the lists and from file
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

        //change a favourites name to a given name in the dictionary and in file
        public void changeFavName(Favourite f, string name)
        {
            foreach (var fav in favs.Where(kvp => kvp.Value.Equals(f)).ToList())
            {
                fav.Value.name = name;
                var favourites = from el in xmlElem.Elements("Favourite")
                                 where (int)el.Element("Id") == fav.Key
                                 select el;
                foreach (XElement xel in favourites)
                {
                    xel.SetElementValue("Name", name);
                }
            }
            xmlElem.Save(fileName);
        }

        //add a new favourite to file with a given id
        private void addFavToFile(int id, Favourite f)
        {
            xmlElem.Add(new XElement("Favourite", new XElement("Id", id), new XElement("Url", f.url), new XElement("Name", f.name)));
            xmlElem.Save(fileName);
        }

        //returns a dictionary containing the browser favourites
        public Dictionary<int, Favourite> getFavourites()
        {
            return favs;
        }
    }

    
}
