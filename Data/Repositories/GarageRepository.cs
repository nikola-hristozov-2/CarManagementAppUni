using CarManagementApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApplication.Data.Repositories
{
    public class GarageRepository(ApplicationDbContext context) : IGarageRepository
    {
        public async Task<IEnumerable<Garage>> GetAllAsync(string? city)
        {
            return await context.Garages.Where(x => city == null || x.City.Contains(city ?? string.Empty)).ToListAsync();
        }

        public async Task<Garage?> GetByIdAsync(long id)
        {
            return await context.Garages.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Garage>?> GetByIdsAsync(IEnumerable<long> ids)
        {
            return await context.Garages.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task AddAsync(Garage entity)
        {
            await context.Garages.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Garage entity)
        {
            context.Garages.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Garage entity)
        {
            context.Garages.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
