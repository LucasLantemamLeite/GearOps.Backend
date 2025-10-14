using GearOps.Api.Enums;

namespace GearOps.Api.Models;

public sealed class Device
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public EType Type { get; set; }
    public EStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? Return { get; set; }
    public bool Active { get; set; }

    public Device(string name, int type, int status, DateTime? startDate, DateTime? returnDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = (EType)type;
        Status = (EStatus)status;
        Start = startDate;
        Return = returnDate;
    }

    public Device(Guid id, string name, int type, int status, DateTime created, DateTime updated, DateTime? startDate, DateTime? returnDate, bool active)
    {
        Id = id;
        Name = name;
        Type = (EType)type;
        Status = (EStatus)status;
        CreatedAt = created;
        UpdatedAt = updated;
        Start = startDate;
        Return = returnDate;
        Active = active;
    }

    private Device() { }
}