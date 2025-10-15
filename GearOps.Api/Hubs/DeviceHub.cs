using GearOps.Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace GearOps.Api.Hubs;

public sealed class DeviceHub : Hub
{
    public async Task DeviceCreated(Device device) => await Clients.All.SendAsync("DeviceCreated", device);

    public async Task DeviceDeleted(Device device) => await Clients.All.SendAsync("DeviceDeleted", device);

    public async Task DeviceUpdated(Device device) => await Clients.All.SendAsync("DeviceUpdated", device);
}