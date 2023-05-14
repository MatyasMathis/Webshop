using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;

namespace WebshopAPI.Profiles;

public class TransactionProfile : Profile
{
    #region Constructors
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionViewDto>();
    }
    #endregion
}
