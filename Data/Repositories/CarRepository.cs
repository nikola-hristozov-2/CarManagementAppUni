using CarManagementApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApplication.Data.Repositories
{
    public class CarRepository(ApplicationDbContext context) : ICarRepository
    {
        public async Task<IEnumerable<Car>> GetAllAsync(string? make, long? garageId, int? fromYear, int? toYear)
        {
            return await context.Cars.Include(x => x.Garages)
                .Where(x => (make == null || x.Make == make) && (garageId == null || x.Garages.Any(x => x.Id == garageId)) && (fromYear == null || x.ProductionYear >= fromYear) && (toYear == null || x.ProductionYear <= toYear))
                .ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(long id)
        {
            return await context.Cars.Include(x => x.Garages).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Car entity)
        {
            await context.Cars.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Car entity)
        {
            context.Cars.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car entity)
        {
            context.Cars.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
