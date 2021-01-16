using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksApp.Model.StockModel;

namespace StocksApp.Model.InvestmentModel
{
    public class StockInvested
    {
        public long Id { get; set; }

        public string name { get; set; }

        public string symbol { get; set; }

        public double amount { get; set; }

        public double priceAquired { get; set; }

        public double totalValue { get; set; }

        public double currentPrice { get; set; }

        public double percentageGainLoss { get; set; }
        
        public double amountGainLoss { get; set; }

        public List<StockHistory> history { get; set; }
    }
}
