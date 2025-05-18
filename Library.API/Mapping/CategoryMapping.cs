using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;

namespace Library.API.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
