using System;

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
