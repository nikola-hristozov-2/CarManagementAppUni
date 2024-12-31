using CarManagementApplication.Data.Entities;

namespace CarManagementApplication.Data.Repositories
{
    public interface IGarageRepository
    {
        Task<IEnumerable<Garage>> GetAllAsync(string? city);
        Task<Garage?> GetByIdAsync(long id);
        Task<IEnumerable<Garage>?> GetByIdsAsync(IEnumerable<long> ids);
        Task AddAsync(Garage entity);
        Task UpdateAsync(Garage entity);
        Task DeleteAsync(Garage entity);
    }
}
