using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IAuthorRepository authorRepository { get; }
        public IBookRepository bookRepository { get; }
        public IBorrowRepository borrowRepository { get; }
        public ICategoryRepository categoryRepository { get; }

        public IPhotoRepository photoRepository { get; }


    }
}
