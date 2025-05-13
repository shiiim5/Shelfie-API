using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities.Books
{
    public class Author:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Bio { get; set; }

        public string ImgUrl { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();



    }
}
