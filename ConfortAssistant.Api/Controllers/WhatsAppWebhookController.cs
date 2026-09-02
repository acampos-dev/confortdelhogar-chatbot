using ConfortAssistant.Api.Dtos;
using ConfortAssistant.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfortAssistant.Api.Controllers;

[ApiController]
[Route("api/whatsapp")]
public class WhatsAppWebhookController : ControllerBase
{
    private readonly IMessageProcessor _messageProcessor;

    public WhatsAppWebhookController(IMessageProcessor messageProcessor)
    {
        _messageProcessor = messageProcessor;
    }

    [HttpPost("webhook")]
    public async Task<IActionResult> ReceiveMessage(
    [FromBody] IncomingWhatsAppMessageDto incomingMessage)
    {
        Console.WriteLine(
            $"Mensaje recibido de {incomingMessage.From}: " +
            incomingMessage.Message);

        string suggestedReply =
            await _messageProcessor.GenerateReplyAsync(
                incomingMessage.Message);

        return Ok(new
        {
            received = true,
            from = incomingMessage.From,
            message = incomingMessage.Message,
            receivedAt = incomingMessage.ReceivedAt,
            suggestedReply
        });
    }
}