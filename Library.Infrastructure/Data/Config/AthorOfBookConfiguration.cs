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
    internal class AthorOfBookConfiguration : IEntityTypeConfiguration<AuthorOfBook>
    {
        public void Configure(EntityTypeBuilder<AuthorOfBook> builder)
        {
           builder.HasData(
     new AuthorOfBook {Id=1  , BookId = 1, AuthorId = 1 },
     new AuthorOfBook {Id=2  , BookId = 2, AuthorId = 2 },
     new AuthorOfBook {Id=3  , BookId = 3, AuthorId = 3 },
     new AuthorOfBook {Id=4  , BookId = 4, AuthorId = 4 },
     new AuthorOfBook {Id=5  , BookId = 5, AuthorId = 5 }
 );

        }
    }
}
