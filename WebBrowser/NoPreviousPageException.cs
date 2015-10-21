using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    class NoPreviousPageException:Exception
    {
        public NoPreviousPageException()
        {
        }

        public NoPreviousPageException(string message)
        : base(message)
    {
        }

        public NoPreviousPageException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
