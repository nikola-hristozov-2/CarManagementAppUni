namespace CarManagementApplication.Services.Dtos
{
    public class YearMonth
    {
        public int Year { get; set; }
        public string Month { get; set; } = string.Empty;
        public bool LeapYear { get; set; }
        public int MonthValue { get; set; }
    }
}
