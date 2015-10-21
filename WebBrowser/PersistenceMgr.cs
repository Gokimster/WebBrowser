using System.IO;
using System.Xml.Linq;

namespace WebBrowser
{
    public class PersistenceMgr
    {
        //----------------------------------------//
        //----------Fieds-------------------------//
        //----------------------------------------//
        protected XElement xmlElem;
        protected string fileName;

        //----------------------------------------//
        //----------Methods-----------------------//
        //----------------------------------------//

        //creates a new document, initialize it as an xml adn save it 
        //with a given name
        protected void createXMLDoc(string name)
        {
            XNamespace empNM = "urn:lst-emp:emp";

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement(empNM + name));

            // Save to Disk
            if (fileName != null)
            {
                xDoc.Save(fileName);
            }
            else
            {
                xDoc.Save("..\\..\\" + name + ".xml");
            }
        }

        //initialize the fields and load the xml file or create it if it doesn't exist
        protected void initXML(string name) 
        {
            fileName = "..\\..\\"+name+".xml";
            try
            {
                xmlElem = XElement.Load(fileName);
            }
            catch (FileNotFoundException e)
            {
                createXMLDoc(name);
                xmlElem = XElement.Load(fileName);
            }
        }

    }
}
