using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDBContext context;

        public IAuthorRepository authorRepository { get; }

        public IBookRepository bookRepository { get; }

        public IBorrowRepository borrowRepository { get; }

        public ICategoryRepository categoryRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public UnitOfWork(LibraryDBContext context)
        {
            this.context = context;
            authorRepository = new AuthorRepository(context);
            bookRepository = new BookRepository(context);
            borrowRepository = new BorrowRepository(context);
            categoryRepository = new CategoryRepository(context);
            photoRepository = new PhotoRepository(context);

        }
    }
}
