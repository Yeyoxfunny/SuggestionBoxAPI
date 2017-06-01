using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestionBoxAPI.Utilities
{
    public class HttpFileUploaderException : Exception
    {
        public HttpFileUploaderException(string message): base(message)
        {

        }

        public HttpFileUploaderException(string message, Exception inner): base(message, inner)
        {

        }
    }
}