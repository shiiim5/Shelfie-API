using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;

namespace Library.API.Mapping
{
    public class AuthorMapping:Profile
    {
        public AuthorMapping()
        {
            CreateMap<AuthorDTO,Author>().ReverseMap();
            CreateMap<UpdateAuthorDTO,Author>().ReverseMap();
        }
    }
}
