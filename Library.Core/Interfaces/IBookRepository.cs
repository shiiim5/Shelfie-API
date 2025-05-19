using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.DTOs;
using Library.Core.Entities.Books;
using Library.Core.Sharing;

namespace Library.Core.Interfaces
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<bool> AddAsync(AddBookDTO bookDTO);
        Task<bool> UpdateAsync(UpdateBookDTO bookDTO);
        Task DeleteAsync(Book book);
        Task<IEnumerable<BookDTO>> GetAllAsync(BookParams bookParams);
    }
}
