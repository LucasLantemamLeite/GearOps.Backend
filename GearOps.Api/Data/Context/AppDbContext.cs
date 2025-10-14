using GearOps.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Data.Context;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Device> Devices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}