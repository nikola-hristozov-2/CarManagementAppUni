namespace CarManagementApplication.Services.Dtos
{
    public class UpdateCarDTO
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int ProductionYear { get; set; }
        public required string LicensePlate { get; set; }
        public required IEnumerable<long> GarageIds { get; set; }
    }
}