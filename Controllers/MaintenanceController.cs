using CarManagementApplication.Services.Dtos;
using CarManagementApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("[controller]")]
public class MaintenanceController(IMaintenanceService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(long? carId, long? garageId)
    {
        return Ok(await service.GetAllAsync(carId, garageId));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([Required] long id)
    {
        return Ok(await service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMaintenanceDTO dto)
    {
        await service.AddAsync(dto);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([Required] long id, [FromBody] UpdateMaintenanceDTO dto)
    {
        await service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([Required] long id)
    {
        await service.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("monthlyRequestsReport")]
    public async Task<IActionResult> GetDailyAvailabilityReport([Required] long garageId, [Required] DateTime startMonth, [Required] DateTime endMonth)
    {
        return Ok(await service.GetMonthlyRequestsReport(garageId, startMonth, endMonth));
    }
}
