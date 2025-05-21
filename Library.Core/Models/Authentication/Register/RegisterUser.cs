using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models.Authentication.Register
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="UserName is Required!")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is Required!")]
        public string? Password { get; set; }
    }
}
