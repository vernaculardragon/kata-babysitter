using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities.MVC
{
    public class APIClient
    {
        private static HttpClient _client;

        public APIClient()
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIURI"] );
            }
        }

        public APIResponse<T> Get<T>(string route)
        {
            return APIResponse<T>.HandleRequest(_client.GetAsync(route).Result);
           
        }
    }
}
