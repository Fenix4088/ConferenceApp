using Confab.Shared.Abstractions.Messaging;
using Confab.Shared.Abstractions.Modules;

namespace Confab.Shared.Infrastructure.Messaging.Brokers;

internal sealed class InMemoryMessageBroker(IModuleClient moduleClient) : IMessageBroker
{
    public async Task PublishAsync(params IMessage[] messages)
    {
        if (messages is null)
        {
            return;
        }
        
        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any())
        {
            return;
        }

        var tasks = new List<Task>();
        
        foreach (var message in messages)
        {
            tasks.Add(moduleClient.PublishAsync(message));
        }

        await Task.WhenAll(tasks);
    }
}