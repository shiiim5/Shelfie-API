using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTOs
{
    public record BorrowDTO
   (int UserId, int BookId, DateTime BorrowDate, DateTime DueDate, DateTime ReturnDate,decimal FineAmount);

    public record UpdateBorrowDTO
  (int UserId, int BookId, DateTime BorrowDate, DateTime DueDate, DateTime ReturnDate, decimal FineAmount,int id);
}
