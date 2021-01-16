using System;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.Model.UserModel
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }

    public class ForgotPassword
    {
        [Required]
        public string Email { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string Password { get; set; }
    }
}
