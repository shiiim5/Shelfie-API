using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Interfaces;
using Library.Core.Services;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDBContext context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;

        public IAuthorRepository authorRepository { get; }

        public IBookRepository bookRepository { get; }

        public IBorrowRepository borrowRepository { get; }

        public ICategoryRepository categoryRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public UnitOfWork(LibraryDBContext context, IMapper mapper, IImageManagementService imageManagementService)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;

            authorRepository = new AuthorRepository(context);
            bookRepository = new BookRepository(context,mapper,imageManagementService);
            borrowRepository = new BorrowRepository(context);
            categoryRepository = new CategoryRepository(context);
            photoRepository = new PhotoRepository(context);
           
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
