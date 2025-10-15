using GearOps.Api.Data.Context;
using GearOps.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Controllers;

[ApiController]
[Route("v1")]
[Tags("Devices")]
public sealed class DeleteDeviceController(AppDbContext context) : ControllerBase
{
    [HttpDelete("device")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteDeviceDto deviceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingDevice = await context.Devices.FirstOrDefaultAsync(d => d.Id == deviceDto.Id);

        if (existingDevice is null)
            return NotFound(new { Message = "Nenhum máquina foi encontrada com esse identificador." });

        context.Devices.Remove(existingDevice);

        var rows = await context.SaveChangesAsync();

        if (rows is 0)
            return BadRequest(new { Message = $"Falha ao deletar o dispositivo de nome: 1{existingDevice.Name}'" });

        return Ok(new { Message = $"Máquina com nome: '{existingDevice.Name}' removido com sucesso." });
    }
}