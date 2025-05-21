using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Entities.Users;

namespace Library.Core.Entities.Books
{
    public class Borrow:BaseEntity<int>
    {
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }

        public virtual ApplicationUser user {get; set;}


        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book book {get; set;}

        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal FineAmount { get; set; }



    }
}
