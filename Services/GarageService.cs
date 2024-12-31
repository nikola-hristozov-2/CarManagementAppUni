using CarManagementApplication.Data.Entities;
using CarManagementApplication.Data.Repositories;
using CarManagementApplication.Services.Dtos;
using CarManagementApplication.Services.Interfaces;

namespace CarManagementApplication.Services
{
    public class GarageService(IGarageRepository garageRepository, IMaintenanceRepository maintenanceRepository) : IGarageService
    {
        public async Task<IEnumerable<ResponseGarageDTO>> GetAllAsync(string? city)
        {
            var garages = await garageRepository.GetAllAsync(city);
            return garages.Select(x => new ResponseGarageDTO(x));
        }

        public async Task<ResponseGarageDTO> GetByIdAsync(long id)
        {
            var garageEntity = await garageRepository.GetByIdAsync(id);
            return garageEntity is null ? throw new KeyNotFoundException("Garage not found") : new ResponseGarageDTO(garageEntity);

        }

        public async Task AddAsync(CreateGarageDTO dto)
        {
            var garage = new Garage
            {
                Name = dto.Name,
                Location = dto.Location,
                City = dto.City,
                Capacity = dto.Capacity
            };

            await garageRepository.AddAsync(garage);
        }

        public async Task UpdateAsync(long id, UpdateGarageDTO dto)
        {
            var garage = await garageRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Garage not found");
            garage.Name = dto.Name;
            garage.Location = dto.Location;
            garage.City = dto.City;
            garage.Capacity = dto.Capacity;

            await garageRepository.UpdateAsync(garage);
        }

        public async Task DeleteAsync(long id)
        {
            var garage = await garageRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Garage not found");
            await garageRepository.DeleteAsync(garage);
        }

        public async Task<List<GarageDailyAvailabilityReportDTO>> GetDailyReportForRange(long id, DateTime startDate, DateTime endDate)
        {
            var garage = await garageRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Garage not found");
            var maintanances = await maintenanceRepository.GetMaintanancesForGarage(id, startDate, endDate);

            var report = new List<GarageDailyAvailabilityReportDTO>();

            while (!((int)new TimeSpan(startDate.Ticks).TotalDays).Equals(((int)new TimeSpan(endDate.Ticks).TotalDays+1)))
            {
                var dailyMaintanances = maintanances.Where(x => x.ScheduledDate.Equals(startDate));

                report.Add(new GarageDailyAvailabilityReportDTO()
                {
                    AvailableCapacity = garage.Capacity - dailyMaintanances.Count(),
                    Date = startDate.ToString("MM-dd-yyyy"),
                    Requests = dailyMaintanances.Count()
                });

                startDate = startDate.AddDays(1);
            }

            return report;
        }
    }
}