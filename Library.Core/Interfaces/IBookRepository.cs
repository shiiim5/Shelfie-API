using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.DTOs;
using Library.Core.Entities.Books;

namespace Library.Core.Interfaces
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<bool> AddAsync(AddBookDTO bookDTO);
        Task<bool> UpdateAsync(UpdateBookDTO bookDTO);
    }
}
