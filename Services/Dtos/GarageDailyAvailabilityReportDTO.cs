﻿namespace CarManagementApplication.Services.Dtos
{
    public class GarageDailyAvailabilityReportDTO
    {
        public string Date { get; set; }

        public int Requests { get; set; }

        public int AvailableCapacity { get; set; }
    }
}
