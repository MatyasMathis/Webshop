using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public interface IProductService : IGenericEntityService
    {
        #region Public members
        Task<bool> BuyProductAsync(string userEmail, BuyProductDto payload);
        Task<List<ProductDto>> SearchProductsAsync(string searchString);
        #endregion
    }

    public class ProductService : GenericEntityService<Product, IProductRepository>, IProductService
    {
        #region Fields
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        public ProductService(IMapper mapper, IProductRepository repository, IUserRepository userRepository,
            ITransactionRepository transactionRepository) : base(mapper, repository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }
        #endregion

        #region Interface Implementations
        public async Task<bool> BuyProductAsync(string userEmail, BuyProductDto payload)
        {
            var user = await _userRepository.GetByEmail(userEmail);
            if (user == null)
                return false;
            var product = await Repository.GetById(payload.ProductId);
            if (product == null)
                return false;

            var transaction = new Transaction
            {
                Amount = payload.Amount, DateTime = DateTime.Now,
                Price = product.Price,
                Product = product,
                User = user
            };
            await _transactionRepository.AddAsync(transaction);
            await Repository.SaveAsync();
            return true;
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string searchString)
        {
            var products = await Repository.SearchAsync(searchString);
            return Mapper.Map<List<ProductDto>>(products);
        }
        #endregion
    }
}
