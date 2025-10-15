using GearOps.Api.Data.Context;
using GearOps.Api.DTOs;
using GearOps.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Controllers;

[ApiController]
[Route("v1")]
[Tags("Devices")]
public sealed class CreateDeviceController(AppDbContext context) : ControllerBase
{
    [HttpPost("device")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateDeviceDto deviceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingDevice = await context.Devices.AsNoTracking().FirstOrDefaultAsync(d => d.Name == deviceDto.Name);

        if (existingDevice is not null)
            return BadRequest(new { Message = "Já existe uma máquina com mesmo nome registrado no sistema." });

        var device = new Device(deviceDto.Name, deviceDto.Type, deviceDto.Status, deviceDto.Start, deviceDto.Return);

        await context.Devices.AddAsync(device);

        var rows = await context.SaveChangesAsync();

        if (rows is 0)
            return BadRequest(new { Message = $"Falha ao adicionar o dispositivo de nome: '{deviceDto.Name}'" });

        return Ok(new { Message = $"Máquina com nome: '{deviceDto.Name}' adicionado com sucesso." });
    }
}