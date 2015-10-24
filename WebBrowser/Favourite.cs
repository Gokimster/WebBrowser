namespace WebBrowser
{
    public class Favourite: Page
    {
        public string name { get; set; }

        //creates a new Favourite with a given url and name
        public Favourite(string url, string name):base(url)
        {
            this.name = name;
        }
    }
}
