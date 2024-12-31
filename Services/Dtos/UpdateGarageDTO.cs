namespace CarManagementApplication.Services.Dtos
{
    public class UpdateGarageDTO
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string City { get; set; }
        public required int Capacity { get; set; }
    }
}