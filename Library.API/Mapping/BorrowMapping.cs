using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;

namespace Library.API.Mapping
{
    public class BorrowMapping:Profile
    {
        public BorrowMapping()
        {
            CreateMap<BorrowDTO,Borrow>().ReverseMap();
            CreateMap<UpdateBorrowDTO,Borrow>().ReverseMap();
        }
    }
}
