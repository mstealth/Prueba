using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Helper
{
    public class FacturaApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1947/");
            return client;
        }
    }
}
