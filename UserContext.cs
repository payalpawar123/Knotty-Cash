using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Identity;

using StocksApp.Helpers;

namespace StocksApp.Model.UserModel
{
    public interface IUserContext
    {
        Task<string> GetQuestion(string email);
        Task<bool> PostQuestion(string email, string answer);
        Task<bool> ResetPassword(string email, string password, PasswordHasher<string> hasher);
        Task PutUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(string id);
    }

    class UserQuery
    {
        public string Key { get; set; }
        public User Object { get; set; }
    }

    public class UserContext : IUserContext
    {
        private readonly FirebaseClient _client;

        public UserContext(IOptions<AppSettings> appSettings)
        {
            _client = new FirebaseClient(appSettings.Value.FirebaseUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(appSettings.Value.FirebaseSecret)
            });

        }

        public async Task PutUser(User user)
        {
            await _client.Child("users").Child(user.Id).PutAsync<User>(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var res = await _client.Child("users").OrderBy("Email").EqualTo(email).OnceAsync<User>();
            if (res.Count > 0)
            {
                return res.ElementAt(0).Object;
            }
            return null;
        }

        public async Task<User> GetUserById(string id)
        {
            return await _client.Child("users").Child(id).OnceSingleAsync<User>();
        }

        public async Task<string> GetQuestion(string email)
        {
            var res = await _client.Child("users").OrderBy("Email").EqualTo(email).OnceAsync<User>();
            if (res.Count > 0)
            {
                return res.ElementAt(0).Object.Question != null ? res.ElementAt(0).Object.Question: "No question found";
            }
            return null;
        }

        public async Task<bool> PostQuestion(string email, string answer)
        {
            var res = await _client.Child("users").OrderBy("Email").EqualTo(email).OnceAsync<User>();
            if (res.Count > 0)
            {
                return res.ElementAt(0).Object.Answer == answer;
            }
            return false;
        }

        public async Task<bool> ResetPassword(string email, string password, PasswordHasher<string> hasher)
        {
            var res = await _client.Child("users").OrderBy("Email").EqualTo(email).OnceAsync<User>();
            if (res.Count > 0)
            {
                var user = res.ElementAt(0).Object;
                user.Password = hasher.HashPassword(user.Id, password);
                await PutUser(user);
                return true;
            }
            return false;
        }
    }
}
