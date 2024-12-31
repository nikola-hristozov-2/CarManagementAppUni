using CarManagementApplication.Data.Entities;
using CarManagementApplication.Data.Repositories;
using CarManagementApplication.Services.Dtos;
using CarManagementApplication.Services.Interfaces;
using System.Globalization;

namespace CarManagementApplication.Services
{
    public class MaintenanceService(IMaintenanceRepository maintananceRepository, IGarageRepository garageRepository, ICarRepository carRepository) : IMaintenanceService
    {
        public async Task<IEnumerable<ResponseMaintenanceDTO>> GetAllAsync(long? carId, long? garageId)
        {
            var maintanences = await maintananceRepository.GetAllAsync(carId, garageId);
            return maintanences.Select(x => new ResponseMaintenanceDTO(x));
        }

        public async Task<ResponseMaintenanceDTO> GetByIdAsync(long id)
        {
            var maintananceEntity = await maintananceRepository.GetByIdAsync(id);
            return maintananceEntity is null ? throw new KeyNotFoundException("Maintenance not found") : new ResponseMaintenanceDTO(maintananceEntity);
        }

        public async Task AddAsync(CreateMaintenanceDTO dto)
        {
            var car = await carRepository.GetByIdAsync(dto.CarId) ?? throw new KeyNotFoundException("Car not found");
            var garage = await garageRepository.GetByIdAsync(dto.GarageId) ?? throw new KeyNotFoundException("Garage not found");

            var maintanances = await maintananceRepository.GetMaintanancesForGarage(garage.Id, dto.ScheduledDate, dto.ScheduledDate);

            if (garage.Capacity > maintanances.Count())
            {
                var maintenance = new Maintenance
                {
                    Car = car,
                    ServiceType = dto.ServiceType,
                    ScheduledDate = dto.ScheduledDate,
                    Garage = garage
                };

                await maintananceRepository.AddAsync(maintenance);
            }
            else
            {
                throw new ApplicationException("Garage has no capacity at that time");
            }
        }

        public async Task UpdateAsync(long id, UpdateMaintenanceDTO dto)
        {
            var car = await carRepository.GetByIdAsync(dto.CarId) ?? throw new KeyNotFoundException("Car not found");
            var garage = await garageRepository.GetByIdAsync(dto.GarageId) ?? throw new KeyNotFoundException("Garage not found");
            var maintenance = await maintananceRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Maintenance not found");
            var maintanances = await maintananceRepository.GetMaintanancesForGarage(garage.Id, dto.ScheduledDate, dto.ScheduledDate);

            if (garage.Capacity > maintanances.Count() || maintenance.ScheduledDate == dto.ScheduledDate)
            {
                maintenance.Car = car;
                maintenance.ServiceType = dto.ServiceType;
                maintenance.ScheduledDate = dto.ScheduledDate;
                maintenance.Garage = garage;

                await maintananceRepository.UpdateAsync(maintenance);
            }
            else
            {
                throw new ApplicationException("Garage has no capacity at that time");
            }
        }

        public async Task DeleteAsync(long id)
        {
            var maintenance = await maintananceRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Maintenance not found");
            await maintananceRepository.DeleteAsync(maintenance);
        }

        public async Task<List<MonthlyRequestsReportDTO>?> GetMonthlyRequestsReport(long garageId, DateTime startDate, DateTime endDate)
        {
            var garage = await garageRepository.GetByIdAsync(garageId) ?? throw new KeyNotFoundException("Garage not found");
            var maintanances = await maintananceRepository.GetMaintanancesForGarage(garageId, startDate, endDate);

            var report = new List<MonthlyRequestsReportDTO>();

             while (!(startDate.Year*12+startDate.Month).Equals(endDate.Year * 12 + endDate.Month + 1))
            {
                var dailyMaintanances = maintanances.Where(x => x.ScheduledDate.Month.Equals(startDate.Month) && x.ScheduledDate.Year.Equals(startDate.Year));

                report.Add(new MonthlyRequestsReportDTO()
                {
                    Requests = dailyMaintanances.Count(),
                    YearMonth = new YearMonth()
                    {
                        LeapYear = DateTime.IsLeapYear(startDate.Year),
                        Month = startDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")).ToUpperInvariant(),
                        MonthValue = startDate.Month,
                        Year = startDate.Year,
                    }
                });

                startDate = startDate.AddMonths(1);
            }

            return report;
        }
    }
}