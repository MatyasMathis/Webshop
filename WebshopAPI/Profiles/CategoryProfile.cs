using AutoMapper;

namespace WebshopAPI.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile() { 
            CreateMap<Models.Category,Models.DTOs.CategoryDto>().ReverseMap();
            CreateMap<Models.DTOs.CategoryDto,Models.Category >().ReverseMap();
        }
    }
}
