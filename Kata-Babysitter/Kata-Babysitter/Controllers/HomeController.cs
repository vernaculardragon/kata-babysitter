using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Common.Contracts.DataContracts;
using Common.Contracts.Routes;
using Common.Utilities.MVC;

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
        public ActionResult Index(Payment Hours)
        {


            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58154/");
            var response = client.GetAsync(PaymentRoute.GetAPIRoute(PaymentRoute.Test));


            return View();
        }


    }
}