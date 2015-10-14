using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    public class Favourite
    {
        public string url { get; set; }
        public string name { get; set; }

        public Favourite(string url, string name)
        {
            this.url = url;
            this.name = name;
        }
    }
}
