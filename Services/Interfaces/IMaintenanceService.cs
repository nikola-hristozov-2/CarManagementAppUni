using CarManagementApplication.Services.Dtos;

namespace CarManagementApplication.Services.Interfaces
{
    public interface IMaintenanceService
    {
        Task<IEnumerable<ResponseMaintenanceDTO>> GetAllAsync(long? carId, long? garageId);
        Task<ResponseMaintenanceDTO> GetByIdAsync(long id);
        Task AddAsync(CreateMaintenanceDTO dto);
        Task UpdateAsync(long id, UpdateMaintenanceDTO dto);
        Task DeleteAsync(long id);
        Task<List<MonthlyRequestsReportDTO>?> GetMonthlyRequestsReport(long garageId, DateTime startDate, DateTime endDate);
    }
}