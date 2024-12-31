using CarManagementApplication.Services.Dtos;
using CarManagementApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("cars")]
public class CarController(ICarService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(string? make, long? garageId, int? fromYear, int? toYear)
    {
        return Ok(await service.GetAllAsync(make, garageId, fromYear, toYear));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([Required] long id)
    {
        return Ok(await service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarDTO dto)
    {
        await service.AddAsync(dto);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([Required] long id, [FromBody] UpdateCarDTO dto)
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
}