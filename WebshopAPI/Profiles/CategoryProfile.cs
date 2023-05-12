using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;

namespace WebshopAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        #region Constructors
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AddCategoryDto, Category>();
        }
        #endregion
    }
}
