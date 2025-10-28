using GearOps.Api.Data.Context;
using GearOps.Api.DTOs;
using GearOps.Api.Enums;
using GearOps.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Controllers;

[ApiController]
[Route("v1")]
[Tags("Devices")]
public sealed class UpdateDeviceController(AppDbContext context, IHubContext<DeviceHub> hub) : ControllerBase
{
    [HttpPut("device")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateDeviceDto deviceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingDevice = await context.Devices.FirstOrDefaultAsync(d => d.Id == deviceDto.Id);

        if (existingDevice is null)
            return NotFound(new { Message = "Nenhuma máquina foi encontrada com esse identificador." });

        var existingName = await context.Devices.FirstOrDefaultAsync(d => d.Name == deviceDto.Name);

        if (existingName is not null && existingName.Id != deviceDto.Id)
            return BadRequest(new { Message = "Já existe uma máquina com mesmo nome registrado no sistema." });

        existingDevice.UpdatedAt = DateTime.UtcNow;
        existingDevice.Name = existingDevice.Name != deviceDto.Name ? deviceDto.Name : existingDevice.Name;
        existingDevice.Type = (int)existingDevice.Type != deviceDto.Type ? (EType)deviceDto.Type : existingDevice.Type;
        existingDevice.Status = (int)existingDevice.Status != deviceDto.Status ? (EStatus)deviceDto.Status : existingDevice.Status;
        existingDevice.Start = existingDevice.Start != deviceDto.Start ? deviceDto.Start : existingDevice.Start;
        existingDevice.Return = existingDevice.Return != deviceDto.Return ? deviceDto.Return : existingDevice.Return;

        context.Devices.Update(existingDevice);

        var rows = await context.SaveChangesAsync();

        if (rows is 0)
            return BadRequest(new { Message = $"Falha ao atualizar o dispositivo '{deviceDto.Name}'" });

        await hub.Clients.All.SendAsync("DeviceUpdated", existingDevice);

        return Ok(new { Message = $"'{deviceDto.Name}' atualizado com sucesso." });
    }
}