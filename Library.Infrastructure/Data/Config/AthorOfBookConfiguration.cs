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


        }
    }
}
