using System;
namespace StocksApp.Model.TransactionModel
{
    public class TransactionRequest
    {
        public string Symbol { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }
    }
}
