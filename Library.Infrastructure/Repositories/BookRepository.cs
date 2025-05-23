﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;
using Library.Core.Interfaces;
using Library.Core.Services;
using Library.Core.Sharing;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryDBContext context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;
        public BookRepository(LibraryDBContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddBookDTO bookDTO)
        {
           if (bookDTO == null) return false;
            var book = mapper.Map<Book>(bookDTO);
           await context.AddAsync(book);
            await context.SaveChangesAsync();

            var imgPath = await imageManagementService.AddImgAsync(bookDTO.Photo,bookDTO.Title);

            var photo = imgPath.Select(path => new Photo
            {
                ImgName = path,
                BookId = book.Id

            }).ToList();
           await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;

        }

      

        public async Task<bool> UpdateAsync(UpdateBookDTO bookDTO)
        {
           if(bookDTO is null)
                return false;
           var findBook = await context.Books.Include(m=>m.category).Include(m=>m.photos).FirstOrDefaultAsync(m=>m.Id == bookDTO.Id);
            if (bookDTO is null)
                return false;
            mapper.Map(bookDTO,findBook);

            var findPhoto = await context.Photos.Where(m => m.BookId == bookDTO.Id).ToListAsync();
            foreach(var item in findPhoto)
            {
                imageManagementService.DeleteImgAsync(item.ImgName);

            }
            context.Photos.RemoveRange(findPhoto);
            var imgPath = await imageManagementService.AddImgAsync(bookDTO.Photo, bookDTO.Title);

            var photo = imgPath.Select(path => new Photo
            {
                ImgName = path,
                BookId = bookDTO.Id
            }).ToList();

            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task DeleteAsync(Book book)
        {
            var photo = await context.Photos.Where(m=>m.BookId == book.Id).ToListAsync();
            foreach(var item in photo)
            {
                imageManagementService.DeleteImgAsync(item.ImgName);
            }
            context.Books.Remove(book);
            await context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync(BookParams bookParams)
        {
            var query = context.Books.Include(m=>m.category).Include(m=>m.photos).AsNoTracking();

            if (!string.IsNullOrEmpty(bookParams.Search)){
                var searchWords = bookParams.Search.Split(' ');
                query = query.Where(m => searchWords.All(word =>
                m.Title.ToLower().Contains(word.ToLower()) ||
                m.Description.ToLower().Contains(word.ToLower())
                ));

            }

            if (bookParams.CategoryId.HasValue)
            {
                query = query.Where(m=>m.CategoryId == bookParams.CategoryId);
            }
            if (!string.IsNullOrEmpty(bookParams.Sort))
            {
                query = bookParams.Sort switch
                {
                    "Ascending" => query.OrderBy(m => m.Title),
                    "Descending" => query.OrderByDescending(m => m.Title),
                    "Available" => query.Where(m => m.AvailableCopies >= 1),
                    _ => query.OrderBy(m => m.Title),
                };
            }
            bookParams.PageNumber = bookParams.PageNumber > 0 ? bookParams.PageNumber : 1;
            bookParams.PageSize = bookParams.PageSize > 0 ? bookParams.PageSize : 3;
            query = query.Skip((bookParams.PageSize) *(bookParams.PageNumber - 1)).Take(bookParams.PageSize);
            var result = mapper.Map<List<BookDTO>>(query);
            return result;
        }
    }
}
