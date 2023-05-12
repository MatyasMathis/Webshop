using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;

namespace WebshopAPI.Profiles
{
    public class ProductProfile : Profile
    {
        #region Constructors
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
        #endregion
    }
}
