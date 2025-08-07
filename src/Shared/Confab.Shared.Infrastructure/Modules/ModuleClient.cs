using Confab.Shared.Abstractions.Modules;

namespace Confab.Shared.Infrastructure.Modules;

public class ModuleClient(IModuleRegistry moduleRegistry, IModuleSerializer moduleSerializer) : IModuleClient
{
    public async Task PublishAsync(object message)
    {
        var key = message.GetType().Name;
        var registrations = moduleRegistry.GetBroadcastRegistrations(key);

        var tasks = new List<Task>();

        foreach (var registration in registrations)
        {
            var action = registration.Action;
            var receiverMsg = TranslateType(message, registration.ReceiverType);
            tasks.Add(action(receiverMsg));
        }

        await Task.WhenAll(tasks);
    }

    private object TranslateType(object value, Type type)
    {
        return moduleSerializer.Deserialize(moduleSerializer.Serialize(value), type);
    }
}