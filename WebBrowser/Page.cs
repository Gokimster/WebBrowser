using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    public class Page
    {
        public string url { get; set; }

        public Page(string url)
        {
            this.url = url;
        }
    }
}
