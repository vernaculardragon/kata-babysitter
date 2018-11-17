using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Routes
{
    public static class PaymentRoute
    {
        public const string Route_Prefix = "api/Payment";

        public const string Calculate = "Calculate";

        public static string GetAPIRoute(string route)
        {
            return $"{Route_Prefix}/{route}";
        }
    }
}
