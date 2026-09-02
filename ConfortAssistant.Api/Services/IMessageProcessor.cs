namespace ConfortAssistant.Api.Services;

public interface IMessageProcessor
{
    Task<string> GenerateReplyAsync(string message);
}