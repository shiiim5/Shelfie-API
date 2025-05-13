using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities.Books
{
    public class AuthorOfBook:BaseEntity<int>
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book book { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author author { get; set; }
    }
}
