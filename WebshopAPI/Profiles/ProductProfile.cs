using AutoMapper;
namespace WebshopAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, Models.DTOs.ProductDto>().ReverseMap();
            CreateMap<Models.DTOs.ProductDto,Models.Product >().ReverseMap();
        }
    }
}
