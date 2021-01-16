using System.Collections.Generic;
using StocksApp.Model.InvestmentModel;
using StocksApp.Model.TransactionModel;

namespace StocksApp.Model.UserModel
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public InvestmentPortfolio InvestmentPortfolio { get; set; }
        public List<Transaction> Transactions { get; set;}
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
