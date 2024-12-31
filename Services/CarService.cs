using CarManagementApplication.Data.Entities;
using CarManagementApplication.Data.Repositories;
using CarManagementApplication.Services.Dtos;
using CarManagementApplication.Services.Interfaces;

namespace CarManagementApplication.Services
{
    public class CarService(ICarRepository carRepository, IGarageRepository garageRepository) : ICarService
    {
        public async Task<IEnumerable<ResponseCarDTO>> GetAllAsync(string? make, long? garageId, int? fromYear, int? toYear)
        {
            var cars = await carRepository.GetAllAsync(make, garageId, fromYear, toYear);
            return cars.Select(x => new ResponseCarDTO(x));
        }

        public async Task<ResponseCarDTO?> GetByIdAsync(long id)
        {
            var carEntity = await carRepository.GetByIdAsync(id);
            return carEntity is null ? throw new KeyNotFoundException("Car not found") : new ResponseCarDTO(carEntity);
        }

        public async Task AddAsync(CreateCarDTO dto)
        {
            var garages = await garageRepository.GetByIdsAsync(dto.GarageIds.ToArray());

            if (!garages?.Any() ?? false)
            {
                throw new KeyNotFoundException("A car should have a garage.");
            }

            var car = new Car
            {
                Make = dto.Make,
                Model = dto.Model,
                ProductionYear = dto.ProductionYear,
                LicensePlate = dto.LicensePlate,
                Garages = garages
            };

            await carRepository.AddAsync(car);
        }

        public async Task UpdateAsync(long id, UpdateCarDTO dto)
        {
            var car = await carRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Car not found");
            var garages = await garageRepository.GetByIdsAsync(dto.GarageIds.ToArray());

            if (!garages?.Any() ?? false)
            {
                throw new KeyNotFoundException("A car should have a garage.");
            }

            car.Make = dto.Make;
            car.Model = dto.Model;
            car.ProductionYear = dto.ProductionYear;
            car.LicensePlate = dto.LicensePlate;
            car.Garages = garages!;

            await carRepository.UpdateAsync(car);
        }

        public async Task DeleteAsync(long id)
        {
            var car = await carRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Car not found");
            await carRepository.DeleteAsync(car);
        }
    }
}