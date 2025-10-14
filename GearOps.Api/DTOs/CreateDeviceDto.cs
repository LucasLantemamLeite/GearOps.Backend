using System.ComponentModel.DataAnnotations;

namespace GearOps.Api.DTOs;

public record CreateDeviceDto
{
    [Required(ErrorMessage = "O nome do dispositivo é obrigatório.")]
    [MaxLength(30, ErrorMessage = "O nome do dispositivo deve possuir no máximo 30 caracteres.")]
    public required string Name { get; init; }

    [Required(ErrorMessage = "O tipo do dispositivo é obrigatório.")]
    [Range(1, 5, ErrorMessage = "O tipo do dispositivo não existe no servidor.")]
    public required int Type { get; init; }

    [Required(ErrorMessage = "O status do dispositivo é obrigatório.")]
    [Range(1, 3, ErrorMessage = "O status do dispositivo não existe no servidor.")]
    public required int Status { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "O início da manutenção está no formato inválido.")]
    public DateTime? Start { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "O retorno da manutenção está no formato inválido.")]
    public DateTime? Return { get; init; }
}