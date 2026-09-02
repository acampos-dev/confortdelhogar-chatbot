using System.ComponentModel.DataAnnotations;

namespace ConfortAssistant.Api.Dtos;

public class IncomingWhatsAppMessageDto
{
    [Required(ErrorMessage = "El número del remitente es obligatorio.")]
    [RegularExpression(
        @"^\d{8,15}$",
        ErrorMessage = "El número debe contener entre 8 y 15 dígitos.")]
    public string From { get; set; } = string.Empty;

    [Required(ErrorMessage = "El mensaje es obligatorio.")]
    [StringLength(
        2000,
        MinimumLength = 1,
        ErrorMessage = "El mensaje debe contener entre 1 y 2000 caracteres.")]
    public string Message { get; set; } = string.Empty;

    public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;
}