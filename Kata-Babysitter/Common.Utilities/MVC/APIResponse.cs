using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities.MVC
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string Errors { get; set; }

        public static APIResponse<T> HandleRequest(HttpResponseMessage response)
        {
            var result = new APIResponse<T>();
            if (response.IsSuccessStatusCode)
            {
                result.IsSuccess = true;
                result.Result = response.Content.ReadAsAsync<T>().Result;

            }
            else
            {
                result.Errors = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}
