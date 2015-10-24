using System;

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
