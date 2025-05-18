using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;

namespace Library.API.Mapping
{
    public class BookMapping:Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookDTO>().ForMember(x=>x.CategoryName,op=>op.MapFrom(src=>src.category.Name)).ReverseMap();
          
            CreateMap<Book,AddBookDTO>().ForMember(x => x.Photo, op => op.Ignore()).ReverseMap();
            CreateMap<Book,UpdateBookDTO>().ForMember(x => x.Photo, op => op.Ignore()).ReverseMap();

            CreateMap<Photo,PhotoDTO>().ReverseMap();

        }
    }
}
