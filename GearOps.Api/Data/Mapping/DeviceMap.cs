using GearOps.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GearOps.Api.Data.Mapping;

public sealed class DeviceMap : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("Devices");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.HasIndex(x => x.Name, "Unique_Key_Name_Devices")
            .IsUnique();

        builder.Property(x => x.Type)
            .HasColumnName("Type")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(x => x.Start)
            .HasColumnName("Start")
            .HasColumnType("timestamptz");

        builder.Property(x => x.Return)
            .HasColumnName("Return")
            .HasColumnType("timestamptz");

        builder.Property(x => x.Active)
            .HasColumnName("Active")
            .HasColumnType("boolean")
            .IsRequired();
    }
}