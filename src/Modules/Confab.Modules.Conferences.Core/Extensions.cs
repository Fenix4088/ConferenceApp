using System.Runtime.CompilerServices;
using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;
using Confab.Modules.Conferences.Core.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Modules.Conferences.Api")]
namespace Confab.Modules.Conferences.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddSingleton<IHostRepository, InMemoryHostRepository>()
            .AddSingleton<IConferenceRepository, InMemoryConferenceRepository>()
            
            .AddSingleton<IConferenceDeletionPolicy, ConferenceDeletionPolicy>()
            .AddSingleton<IHostDeletionPolicy, HostDeletionPolicy>()
            
            .AddScoped<IConferenceService, ConferenceService>()
            .AddScoped<IHostService, HostService>();
        
        return services;
    }

}