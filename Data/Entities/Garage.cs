namespace CarManagementApplication.Data.Entities
{
    public class Garage : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}