using System;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.Model.StockModel
{

    public class StockRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
