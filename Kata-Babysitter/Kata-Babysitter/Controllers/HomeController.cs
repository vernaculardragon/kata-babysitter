using System.Web.Mvc;
using Common.Contracts.DataContracts;
using Common.Contracts.Routes;
using Common.Utilities.MVC;
using Common.Utilities.Extensions;

namespace Kata_Babysitter.Controllers
{
    public class HomeController : Controller
    {
        private APIClient _client = new APIClient();

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Payment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(Payment Hours)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelErrors(Hours.Validate());

                if (ModelState.IsValid)
                {
                    var result =
                        _client.Post<Payment, Payment>(PaymentRoute.GetAPIRoute(PaymentRoute.Calculate), Hours);

                    return View(result.Result);
                }
            }
           
            return View(Hours);
        }


    }
}