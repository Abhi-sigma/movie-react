using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ServiceLayer
{
    public interface IHttpCaller
    {
      
        public string Request(string uri);
    }
}
