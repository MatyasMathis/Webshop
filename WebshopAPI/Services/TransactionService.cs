using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services;

public interface ITransactionService : IGenericEntityService
{
}

public class TransactionService : GenericEntityService<Transaction, ITransactionRepository>, ITransactionService
{
    #region Constructors
    public TransactionService(IMapper mapper, ITransactionRepository repository) : base(mapper, repository)
    {
    }
    #endregion
}
