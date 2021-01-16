using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StocksApp.Model.InvestmentModel;

namespace StocksApp.Model
{
    public class Response
    {
        public bool success { get; set; }

        public string symbols_requested { get; set; }

        public string symbols_returned { get; set; }

        public List<Stock> data { get; set; }

    }

}
