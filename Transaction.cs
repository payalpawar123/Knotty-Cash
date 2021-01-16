using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksApp.Model.TransactionModel
{

    public enum TransactionType
    {
        buy = 0,
        sell = 1
    }


    public class Transaction
    {
        public string Id { get; set; }
        public TransactionType Type { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
