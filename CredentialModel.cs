using System;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.Model.UserModel
{
    public class CredentialModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
