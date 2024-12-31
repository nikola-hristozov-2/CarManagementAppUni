namespace CarManagementApplication.Services.Dtos
{
    public class MonthlyRequestsReportDTO
    {
        public YearMonth YearMonth { get; set; } = new YearMonth();

        public int Requests { get; set; }
    }
}
