namespace CarManagementApplication.Services.Dtos
{
    public class UpdateMaintenanceDTO
    {
        public required long CarId { get; set; }
        public required string ServiceType { get; set; }
        public required DateTime ScheduledDate { get; set; }
        public required long GarageId { get; set; }
    }
}