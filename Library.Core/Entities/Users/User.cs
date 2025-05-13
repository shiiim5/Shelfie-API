using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Entities.Books;

namespace Library.Core.Entities.Users
{
    public class User:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public virtual List<Borrow> borrows { get; set; } = new List<Borrow>();
    }
}
