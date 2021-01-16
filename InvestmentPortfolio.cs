using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksApp.Model.InvestmentModel
{
    public class InvestmentPortfolio
    {

        public long Id { get; set; }

        public string userId { get; set; }

        public double cashAvailable { get; set; }

        public double totalValue { get; set; }

        public double totalGainLoss { get; set; }

        public double percentGainLoss { get; set; }

        public List<StockInvested> holdings { get; set; }

    }
}
