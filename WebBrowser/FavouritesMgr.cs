using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebBrowser
{
    public class FavouritesMgr
    {
        private XElement favXML;
        private string favFileName;
        private Dictionary<int, Favourite> favs;

        public FavouritesMgr()
        {
            favFileName = "..\\..\\Favourites.xml";
            try
            {
                favXML = XElement.Load(favFileName);
            }
            catch (FileNotFoundException e)
            {
                createXMLDoc("Favourites");
                favXML = XElement.Load(favFileName);
            }

            favs = new Dictionary<int, Favourite>();
            foreach(var f in favXML.Elements())
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
            favXML.Add(new XElement("Favourite", new XElement("Id", id), new XElement("Url", f.url), new XElement("Name", f.name)));
            favXML.Save(favFileName);
        }

        private static void createXMLDoc(string name)
        {
            XNamespace empNM = "urn:lst-emp:emp";

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement(empNM + name));

            // Save to Disk
            xDoc.Save("..\\..\\"+name+".xml");
        }

        public Dictionary<int, Favourite> getFavourites()
        {
            return favs;
        }
    }

    
}
