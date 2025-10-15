using System.ComponentModel.DataAnnotations;

namespace GearOps.Api.DTOs;

public record DeleteDeviceDto
{
    [Required(ErrorMessage = "O identificador do dispositivo é obrigatório.")]
    public required Guid Id { get; init; }
}