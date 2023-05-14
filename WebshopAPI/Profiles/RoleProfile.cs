using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;

namespace WebshopAPI.Profiles;

public class RoleProfile : Profile
{
    #region Constructors
    public RoleProfile()
    {
        CreateMap<Role, RoleViewDto>();
    }
    #endregion
}
