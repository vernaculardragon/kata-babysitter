using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public static class Constants
    {
        //This should probably come from a DB or other configurable source. 
        //Could have put this in a web.config, however for the scope of this project the extra parsing time seemed overkill

        public static decimal PreBedRate = (decimal) 12.00;
        public static decimal PostBedRate = (decimal)8.00;
        public static decimal PostMidnightRate = (decimal)16.00;
    }
}
