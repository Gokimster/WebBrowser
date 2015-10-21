using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    class NoNextPageException:Exception
    {
        public NoNextPageException()
        {
        }

        public NoNextPageException(string message)
        : base(message)
    {
        }

        public NoNextPageException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
