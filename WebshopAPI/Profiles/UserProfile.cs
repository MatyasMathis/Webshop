using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;

namespace WebshopAPI.Profiles;

public class UserProfile : Profile
{
    #region Constructors
    public UserProfile()
    {
        CreateMap<User, UserViewDto>();
    }
    #endregion
}
