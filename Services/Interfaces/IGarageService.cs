using CarManagementApplication.Services.Dtos;

namespace CarManagementApplication.Services.Interfaces
{
    public interface IGarageService
    {
        Task<IEnumerable<ResponseGarageDTO>> GetAllAsync(string? city);
        Task<ResponseGarageDTO> GetByIdAsync(long id);
        Task AddAsync(CreateGarageDTO dto);
        Task UpdateAsync(long id, UpdateGarageDTO dto);
        Task DeleteAsync(long id);
        Task<List<GarageDailyAvailabilityReportDTO>> GetDailyReportForRange(long id, DateTime startDate, DateTime endDate);
    }
}