using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities.Books
{
    public class Book:BaseEntity<int>
    {
        public string Title { get; set; }
   
        public string ISBN { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public int AvailableCopies { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

       public virtual Category category {  get; set; }

        public virtual List<Photo>? photos { get; set; } = new List<Photo>();

        public virtual List<Author>? authors { get; set; } = new List<Author>();
        public virtual List<Borrow>? Borrows { get; set; } = new List<Borrow>();



    }
}
