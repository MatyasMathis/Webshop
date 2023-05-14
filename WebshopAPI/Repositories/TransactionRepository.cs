using WebshopAPI.Data;
using WebshopAPI.Models;

namespace WebshopAPI.Repositories;

public interface ITransactionRepository : IGenericRepository<Transaction>
{
}

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    #region Constructors
    public TransactionRepository(WebshopDbContext webshopDbContext) : base(webshopDbContext)
    {
    }
    #endregion
}
