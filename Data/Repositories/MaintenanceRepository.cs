using CarManagementApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApplication.Data.Repositories
{
    public class MaintenanceRepository(ApplicationDbContext context) : IMaintenanceRepository
    {
        public async Task<IEnumerable<Maintenance>> GetAllAsync(long? carId, long? garageId)
        {
            return await context.Maintenances.Include(x => x.Car).Include(x => x.Garage)
                .Where(x => (carId == null || x.Car.Id == carId) && (garageId == null || x.Garage.Id == garageId))
                .ToListAsync();
        }

        public async Task<Maintenance?> GetByIdAsync(long id)
        {
            return await context.Maintenances.Include(x => x.Car).Include(x => x.Garage).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Maintenance>?> GetMaintanancesForGarage(long garageId, DateTime startDate, DateTime endDate)
        {
            return await context.Maintenances.Include(x => x.Car).Include(x => x.Garage).Where(x => x.Garage.Id == garageId && x.ScheduledDate.CompareTo(startDate) >= 0 && x.ScheduledDate.CompareTo(endDate) <= 0).ToListAsync();
        }

        public async Task AddAsync(Maintenance entity)
        {
            await context.Maintenances.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Maintenance entity)
        {
            context.Maintenances.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Maintenance entity)
        {
            context.Maintenances.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
