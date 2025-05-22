using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models.Authentication.Login
{
    public class LoginUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is Required!")]
        public string? Password { get; set; }
    }
}
