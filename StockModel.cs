using System;
using System.Collections.Generic;

namespace StocksApp.Model.StockModel
{
    public class StockHistory
    {
        public string c { get; set; }
        public string h { get; set; }
        public string l { get; set; }
        public string o { get; set; }
        public string t { get; set; }
        public string tm { get; set; }
        public string v { get; set; }
    }

    public class StockModel
    {
        public long Id { get; set; }

        public String Symbol { get; set; }

        public String Name { get; set; }

        public double Price { get; set; }

        public string ConfidenceInterval { get; set; }

        public double DayChangePCT { get; set; }

        public List<StockHistory> History { get; set; }

    }
}
