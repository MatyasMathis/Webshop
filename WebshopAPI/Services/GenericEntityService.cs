using AutoMapper;
using WebshopAPI.Models;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services;

public interface IGenericEntityService
{
    #region Public members
    Task<Guid> AddAsync<TDto>(TDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<List<TDto>> GetAllAsync<TDto>();
    Task<TDto?> GetByIdAsync<TDto>(Guid id) where TDto : class;
    Task<bool> UpdateAsync<TDto>(Guid entryId, TDto newValues);
    #endregion
}

public abstract class GenericEntityService<TEntity, TRepo> : IGenericEntityService
    where TEntity : class, IIdentifiableByGuid
    where TRepo : IGenericRepository<TEntity>
{
    #region Fields
    protected readonly IMapper Mapper;
    protected readonly TRepo Repository;
    #endregion

    #region Constructors
    protected GenericEntityService(IMapper mapper, TRepo repository)
    {
        Mapper = mapper;
        Repository = repository;
    }
    #endregion

    #region Interface Implementations
    public async Task<Guid> AddAsync<TDto>(TDto dto)
    {
        var entry = Mapper.Map<TEntity>(dto);
        await Repository.AddAsync(entry);
        await Repository.SaveAsync();
        return entry.Id;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await Repository.DeleteAsync(id);
        if (result)
            await Repository.SaveAsync();
        return result;
    }

    public async Task<List<TDto>> GetAllAsync<TDto>()
    {
        var dbEntries = await Repository.GetAll();
        return Mapper.Map<List<TDto>>(dbEntries);
    }

    public async Task<TDto?> GetByIdAsync<TDto>(Guid id) where TDto : class
    {
        var entry = await Repository.GetById(id);
        if (entry == null)
            return null;
        return Mapper.Map<TDto>(entry);
    }

    public async Task<bool> UpdateAsync<TDto>(Guid entryId, TDto newValues)
    {
        var existing = await Repository.GetById(entryId);
        if (existing == null)
            return false;
        Mapper.Map(newValues, existing);
        await Repository.SaveAsync();
        return true;
    }
    #endregion
}
