using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StocksApp.Model.CustomerModel;
using StocksApp.Model.InvestmentModel;

namespace StocksApp.Mocks
{
    public class MockData
    {
        //Creates mock customer.
        public Customer MockCustomer() {

            Customer mockCustomer = new Customer();

            //Id
            mockCustomer.id = "123456";

            //UserInfo.
            UserInfo userInfo = new UserInfo {

                name = "Ricardo",
                lastName = "Ruiz",
                email = "ricardo.ruiz@ttu.edu"

            };

            mockCustomer.info = userInfo;

            //Investment portfolio.
            InvestmentPortfolio investmentPortfolio = new InvestmentPortfolio();

            investmentPortfolio.userId = "1234";

            //Retrieving portfolio will come from the database.

            investmentPortfolio.cashAvailable = 2000;

            investmentPortfolio.totalValue = investmentPortfolio.cashAvailable + 5;

            investmentPortfolio.holdings = new List<StockInvested> {

                new StockInvested() {

                    symbol = "APHA",
                    name = "Aphria Inc.",
                    amount = 1,
                    priceAquired = 5.40,
                    currentPrice = 5.20,
                    percentageGainLoss = -0.2,
                    amountGainLoss = -0.2,
                    totalValue = 5.2f
                    
                }

            };

            investmentPortfolio.totalGainLoss = -0.2;
            investmentPortfolio.percentGainLoss = -0.2;
 
            mockCustomer.investmentPortfolio = investmentPortfolio;

            return mockCustomer;

        }


    }
}
