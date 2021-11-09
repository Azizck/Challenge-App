using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace JokeGenerator
{
    public class HttpSerivce
    {
        public  HttpClient _client { get; }
        public HttpSerivce(string baseUrl)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }
    }
}
