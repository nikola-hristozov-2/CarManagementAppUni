using CarManagementApplication.Services.Dtos;
using CarManagementApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("garages")]
public class GarageController(IGarageService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(string? city)
    {
        return Ok(await service.GetAllAsync(city));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([Required] long id)
    {
        return Ok(await service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGarageDTO dto)
    {
        await service.AddAsync(dto);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([Required] long id, [FromBody] UpdateGarageDTO dto)
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

    [HttpGet("dailyAvailabilityReport")]
    public async Task<IActionResult> GetDailyAvailabilityReport([Required] long garageId, [Required] DateTime startDate, [Required] DateTime endDate)
    {
        return Ok(await service.GetDailyReportForRange(garageId, startDate, endDate));
    }
}
