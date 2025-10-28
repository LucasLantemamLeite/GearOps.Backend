using GearOps.Api.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Controllers;

[ApiController]
[Route("v1")]
[Tags("Devices")]
public sealed class GetDeviceController(AppDbContext context) : ControllerBase
{
    [HttpGet("device")]
    public async Task<IActionResult> GetAsync()
    {
        var devices = await context.Devices.AsNoTracking().OrderBy(x => x.Type).ToListAsync();

        if (devices.Count is 0)
            return Ok(new { Message = "Nenhuma máquina registrada no sistema." });

        return Ok(new { Data = devices });
    }
}