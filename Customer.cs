using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StocksApp.Model;
using StocksApp.Model.CustomerModel;
using StocksApp.Model.InvestmentModel;

namespace StocksApp.Model.CustomerModel
{
    public class Customer
    {

        public string id { get; set; }

        public UserInfo info { get; set; }

        public InvestmentPortfolio investmentPortfolio { get; set; }

    }
}
