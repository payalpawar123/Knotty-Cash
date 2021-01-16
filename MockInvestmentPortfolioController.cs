using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using StocksApp.Model.CustomerModel;
using StocksApp.Mocks;

using Newtonsoft.Json;

namespace StocksApp.Controllers
{
    public class MockInvestmentPortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("MockInvestmentPortfolio/MockInvestmentFolio")]
        public IActionResult MockInvestmentFolio() {

            MockData mock = new MockData();

            var serialized = JsonConvert.SerializeObject(mock.MockCustomer());

            return View("~/Pages/Views/InvestmentPortfolioView.cshtml", mock.MockCustomer());

        }

    }
}
