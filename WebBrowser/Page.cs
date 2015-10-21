
namespace WebBrowser
{
    public class Page
    {
        public string url { get; set; }

        //creates a new page with a given url
        public Page(string url)
        {
            this.url = url;
        }
    }
}
