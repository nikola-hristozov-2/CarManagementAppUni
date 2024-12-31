namespace CarManagementApplication.Data.Entities
{
    public class Maintenance : BaseEntity
    {
        public Car Car { get; set; }
        public string ServiceType { get; set; }
        public DateTime ScheduledDate { get; set; }
        public Garage Garage { get; set; }
    }
}