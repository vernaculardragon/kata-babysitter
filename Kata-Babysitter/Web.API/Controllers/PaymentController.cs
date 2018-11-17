using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using BabySitter.BL;
using Common.Contracts.DataContracts;
using Common.Contracts.Routes;

namespace Web.API.Controllers
{
    [RoutePrefix(PaymentRoute.Route_Prefix)]
    public class PaymentController : ApiController
    {
     

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route(PaymentRoute.Calculate)]
        [HttpPost]
        public Payment CalculatePayment(Payment hours)
        {
            var BL = new PaymentBL();
            return BL.CalcAmountOwed(hours);
        }

      
    }
}
