using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Config
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
           builder.HasData(
    new Author {Id=1  , Name = "Isaac Asimov", Bio = "Science fiction legend", ImgUrl = "/images/authors/asimov.jpg" },
    new Author {Id= 2 , Name = "Stephen Hawking", Bio = "Physicist and cosmologist", ImgUrl = "/images/authors/hawking.jpg" },
    new Author {Id=  3, Name = "Agatha Christie", Bio = "Queen of Mystery", ImgUrl = "/images/authors/christie.jpg" },
    new Author {Id=4  , Name = "Walter Isaacson", Bio = "Biographer of geniuses", ImgUrl = "/images/authors/isaacson.jpg" },
    new Author {Id= 5 , Name = "Plato", Bio = "Greek philosopher", ImgUrl = "/images/authors/plato.jpg" }
);

        }
    }
}
