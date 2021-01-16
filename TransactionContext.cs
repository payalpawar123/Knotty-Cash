using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Extensions.Options;

using StocksApp.Helpers;
using StocksApp.Model.UserModel;

namespace StocksApp.Model.TransactionModel
{
    public interface ITransactionContext
    {
        Task<Transaction> BuyStock(TransactionRequest req);
        Task<Transaction> SellStock(TransactionRequest req);
    }

    public class TransactionContext : ITransactionContext
    {
        private readonly FirebaseClient _client;
        private readonly UserContext _userContext;

        public TransactionContext(IOptions<AppSettings> appSettings, UserContext userContext)
        {
            _userContext = userContext;
            _client = new FirebaseClient(appSettings.Value.FirebaseUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(appSettings.Value.FirebaseSecret)
            });
        }

        public Task<Transaction> BuyStock(TransactionRequest req)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> SellStock(TransactionRequest req)
        {
            throw new NotImplementedException();
        }

    }


}
