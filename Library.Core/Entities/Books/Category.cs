using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities.Books
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
