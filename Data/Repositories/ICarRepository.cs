using CarManagementApplication.Data.Entities;

namespace CarManagementApplication.Data.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync(string? make, long? garageId, int? fromYear, int? toYear);
        Task<Car?> GetByIdAsync(long id);
        Task AddAsync(Car entity);
        Task UpdateAsync(Car entity);
        Task DeleteAsync(Car entity);
    }
}
