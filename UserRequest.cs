using System;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.Model.UserModel
{
    public class UserRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public double Cash { get; set; }
    }
}
