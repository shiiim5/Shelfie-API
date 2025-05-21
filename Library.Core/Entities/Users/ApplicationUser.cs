using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Entities.Books;
using Microsoft.AspNetCore.Identity;

namespace Library.Core.Entities.Users
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }

        [StringLength(20, MinimumLength = 6)]
        [RegularExpression(@"^[A-Za-z0-9\-]{6,20}$", ErrorMessage = "Invalid National ID format.")]
        public string? NationalId { get; set; }

        public virtual List<Borrow> borrows { get; set; } = new List<Borrow>();

    }
}
