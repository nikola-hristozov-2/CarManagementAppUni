using CarManagementApplication.Data.Entities;

namespace CarManagementApplication.Services.Dtos
{
    public class ResponseGarageDTO(Garage garageEntity)
    {
        public long Id { get; } = garageEntity.Id;
        public string Name { get; } = garageEntity.Name;
        public string Location { get; } = garageEntity.Location;
        public string City { get; } = garageEntity.City;
        public int Capacity { get; } = garageEntity.Capacity;
    }
}