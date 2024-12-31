using CarManagementApplication.Services.Dtos;

namespace CarManagementApplication.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<ResponseCarDTO>> GetAllAsync(string? make, long? garageId, int? fromYear, int? toYear);
        Task<ResponseCarDTO?> GetByIdAsync(long id);
        Task AddAsync(CreateCarDTO dto);
        Task UpdateAsync(long id, UpdateCarDTO dto);
        Task DeleteAsync(long id);
    }
}