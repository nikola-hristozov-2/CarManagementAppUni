using CarManagementApplication.Data.Entities;

namespace CarManagementApplication.Data.Repositories
{
    public interface IMaintenanceRepository
    {
        Task<IEnumerable<Maintenance>> GetAllAsync(long? carId, long? garageId);
        Task<Maintenance?> GetByIdAsync(long id);
        Task<IEnumerable<Maintenance>?> GetMaintanancesForGarage(long garageId, DateTime startDate, DateTime endDate);
        Task AddAsync(Maintenance entity);
        Task UpdateAsync(Maintenance entity);
        Task DeleteAsync(Maintenance entity);
    }
}
