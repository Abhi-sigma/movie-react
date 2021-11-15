using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ServiceLayer
{
    public class HttpRequestor : IHttpCaller
    {
        private readonly HttpClient _httpClient;
        public HttpRequestor(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public string Request(string uri)
        {
            //http://www.omdbapi.com/?t={0}&apikey=5d9755d
            var response = _httpClient.GetStringAsync(uri);
            return response.Result;
        }

    }
}
