namespace CarManagementApplication.Data.Entities
{
    public class Car : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string LicensePlate { get; set; }
        public IEnumerable<Garage> Garages { get; set; }
    }
}