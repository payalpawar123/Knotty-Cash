using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using StocksApp.Model.CustomerModel;

namespace StocksApp.Controllers
{
    public class TradingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Trading/Transaction")]
        public ActionResult Transaction(Customer currentCustomer) {

            return View("~/Pages/Views/TransactionsView.cshtml", currentCustomer);

        }


    }
}