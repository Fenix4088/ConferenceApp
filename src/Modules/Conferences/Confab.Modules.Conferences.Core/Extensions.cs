using System.Runtime.CompilerServices;
using Confab.Modules.Conferences.Core.DAL;
using Confab.Modules.Conferences.Core.DAL.Repositories;
using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;
using Confab.Modules.Conferences.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Modules.Conferences.Api")]
namespace Confab.Modules.Conferences.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddPostgres<ConferencesDbContext>()
            // .AddSingleton<IHostRepository, InMemoryHostRepository>()
            // .AddSingleton<IConferenceRepository, InMemoryConferenceRepository>()
            .AddScoped<IHostRepository, HostRepository>()
            .AddScoped<IConferenceRepository, ConferenceRepository>()
            
            .AddSingleton<IConferenceDeletionPolicy, ConferenceDeletionPolicy>()
            .AddSingleton<IHostDeletionPolicy, HostDeletionPolicy>()
            
            .AddScoped<IConferenceService, ConferenceService>()
            .AddScoped<IHostService, HostService>();
        
        return services;
    }

}