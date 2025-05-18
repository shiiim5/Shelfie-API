using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Entities.Books;
using Microsoft.AspNetCore.Http;

namespace Library.Core.DTOs
{
    public record BookDTO
   (string Title,string Author,string ISBN,string Description,int Quantity, int AvailableCopies, string CategoryName, List<Photo> photos);

    public record UpdateBookDTO : AddBookDTO
    {
        public int Id { get; set; }
    }

    public record PhotoDTO
        (int id, string ImgName, int BookId);

    public record AddBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int AvailableCopies { get; set; }
        public int CategoryId { get; set; }
        public IFormFileCollection Photo { get; set; }
    }

}
