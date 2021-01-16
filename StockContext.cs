using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

using StocksApp.Helpers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using StocksApp.Model.TransactionModel;

namespace StocksApp.Model.StockModel
{

    public interface IStockContext
    {
        Task<StockModel> GetStockBySymbol(string symbol);
        Task<List<StockModel>> GetStocksBySymbols(List<string> symbols);
        Task<List<StockHistory>> GetStockHistory(string symbol);
    }

    public class StockContext : IStockContext
    {
        private readonly HttpClient http;
        private readonly FirebaseClient _client;
        public StockContext(IOptions<AppSettings> appSettings)
        {
            http = new HttpClient();
            _client = new FirebaseClient(appSettings.Value.FirebaseUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(appSettings.Value.FirebaseSecret)
            });
        }

        private string CalculateConfidenceInterval(Object stock)
        {
            return "low risk";
        }

        public async Task<StockModel> GetStockBySymbol(string symbol)
        {
            var stocks = await GetStocksBySymbols(new List<string>() { symbol });
            return stocks.Count() > 0 ? stocks[0] : null;
        }

        public async Task<List<StockModel>> GetStocksBySymbols(List<string> symbols)
        {
            if (symbols == null)
            {
                symbols = new List<string>(){
                        "ACB",
                        "APHA",
                        "F",
                        "HEXO"
                        };

            }
            var result = new List<StockModel>();

            foreach(var symbol in symbols)
            {
                var stock = await _client.Child("stocks").Child(symbol).OnceSingleAsync<StockModel>();
                result.Add(stock);
            }

            return result;
        }

        public async Task<List<StockHistory>> GetStockHistory(string symbol)
        {
            var stock = await _client.Child("stocks").Child(symbol).OnceSingleAsync<StockModel>();
            return stock.History;
        }

        //public async Task<StockModel> GetStockBySymbol(string symbol)
        //{
        //    string uri = string.Format("https://api.worldtradingdata.com/api/v1/stock?symbol={0}&api_token=LpXcLeQM6OlaKoLeHbG9rw962RSIX2gpHsJNkm1BzgjboFzqNMwixbBuXQDP", symbol);

        //    var response = http.GetAsync(uri).Result;
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();

        //    var converted = JsonConvert.DeserializeObject<Response>(responseBody);

        //    return converted.data[0] == null ? null: new StockModel()
        //    {

        //        Id = 1234,
        //        Symbol = converted.data[0].symbol,
        //        Name = converted.data[0].name,
        //        Price = converted.data[0].price,
        //        ConfidenceInterval = CalculateConfidenceInterval(converted.data[0])
        //    };
        //}
        //public async Task<string> GetStockHistory(string symbol)
        //{
        //    var historyResponse = http.GetAsync(string.Format("https://api.worldtradingdata.com/api/v1/history?symbol={0}&api_token=LpXcLeQM6OlaKoLeHbG9rw962RSIX2gpHsJNkm1BzgjboFzqNMwixbBuXQDP", symbol)).Result;
        //    historyResponse.EnsureSuccessStatusCode();
        //    return await historyResponse.Content.ReadAsStringAsync();
        //}

        //public async Task<List<StockModel>> GetStocksBySymbols(List<string> symbols)
        //{
        //    if (symbols == null)
        //    {
        //        symbols = new List<string>(){
        //        "CRON",
        //        "MSFT",
        //        "AAPL",
        //        "F"
        //        };

        //    }

        //    string requested_symbols = string.Join(",", symbols);

        //    string uri = string.Format("https://api.worldtradingdata.com/api/v1/stock?symbol={0}&api_token=LpXcLeQM6OlaKoLeHbG9rw962RSIX2gpHsJNkm1BzgjboFzqNMwixbBuXQDP", requested_symbols);

        //    var response = http.GetAsync(uri).Result;
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();

        //    var converted = JsonConvert.DeserializeObject<Response>(responseBody);
        //    Console.WriteLine(converted);

        //    var result = new List<StockModel>();

        //    foreach (var stock in converted.data)
        //    {
        //        var historyResponse = http.GetAsync(string.Format("https://api.worldtradingdata.com/api/v1/history?symbol={0}&api_token=LpXcLeQM6OlaKoLeHbG9rw962RSIX2gpHsJNkm1BzgjboFzqNMwixbBuXQDP", stock.symbol)).Result;
        //        historyResponse.EnsureSuccessStatusCode();
        //        string historyBody = await historyResponse.Content.ReadAsStringAsync();

        //        result.Add(new StockModel()
        //        {
        //            Id = 1234,
        //            Symbol = stock.symbol,
        //            Name = stock.name,
        //            Price = stock.price,
        //            ConfidenceInterval = CalculateConfidenceInterval(stock),
        //            History = historyBody,
        //        });

        //    }
        //    return result;
        //}
    }
}
