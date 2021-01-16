using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace StocksApp.Model.InvestmentModel
{
    public class InvestmentPortfolioContext : DbContext
    {

        public InvestmentPortfolioContext(DbContextOptions<InvestmentPortfolioContext> options) : base(options) {

        }

        public DbSet<InvestmentPortfolio> InvestmentPortfolios { get; set; }

    }
}
