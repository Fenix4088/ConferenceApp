namespace Confab.Shared.Infrastructure.Modules;

internal sealed class ModuleRegistry : IModuleRegistry
{
    private readonly List<ModuleBroadcastRegistration> broadcastRegistrations = new();
    
    public IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key)
    {
        return broadcastRegistrations.Where(x => x.Key == key);
    }

    public void AddBroadcastAction(Type requestType, Func<object, Task> action)
    {
        if (string.IsNullOrWhiteSpace(requestType.Namespace))
        {
            throw new InvalidOperationException("Missing namespace.");
        }
        
        var registration = new ModuleBroadcastRegistration(requestType, action);
        broadcastRegistrations.Add(registration);
    }
}