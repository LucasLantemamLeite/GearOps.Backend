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
        var devices = await context.Devices.AsNoTracking().OrderBy(x => x.Type).Skip((page - 1) * count).Take(count).ToListAsync();

        if (devices.Count is 0)
            return Ok(new { Message = "Nenhuma máquina registrada no sistema." });

        var items = devices.Count;
        
        return Ok(new { Message = $"Entregue {(items <= 1 ? " " : "as")} {items} {(items <= 1 ? "máquina": "máquinas")} registrados no sistema.", Data = devices });
    }
}