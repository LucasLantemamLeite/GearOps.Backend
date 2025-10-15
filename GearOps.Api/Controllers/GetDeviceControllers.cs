using GearOps.Api.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Controllers;

[ApiController]
[Route("v1")]
[Tags("Devices")]
public sealed class GetDeviceController(AppDbContext context) : ControllerBase
{
    [HttpGet("device/{count:int}/{page:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int count, [FromRoute] int page)
    {
        var devices = await context.Devices.AsNoTracking().Skip((page - 1) * count).Take(count).ToListAsync();

        if (devices.Count is 0)
            return NotFound(new { Message = "Nenhuma máquina registrada no sistema." });

        return Ok(new { Message = $"Entregue as {devices.Count} registrados no sistema.", Data = devices });
    }
}