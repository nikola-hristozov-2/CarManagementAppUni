using CarManagementApplication.Data.Entities;

namespace CarManagementApplication.Services.Dtos
{
    public class ResponseMaintenanceDTO(Maintenance maintenanceEntity)
    {
        public long Id { get; } = maintenanceEntity.Id;
        public long CarId { get; } = maintenanceEntity.Car.Id;
        public string CarName { get; } = $"{maintenanceEntity.Car.Make} {maintenanceEntity.Car.Model}";
        public string ServiceType { get; } = maintenanceEntity.ServiceType;
        public string ScheduledDate { get; } = maintenanceEntity.ScheduledDate.ToString("MM-dd-yyyy");
        public long GarageId { get; } = maintenanceEntity.Garage.Id;
        public string GarageName { get; } = maintenanceEntity.Garage.Name;
    }
}