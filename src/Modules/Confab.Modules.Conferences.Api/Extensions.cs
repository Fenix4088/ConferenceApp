using System.Runtime.CompilerServices;
using Confab.Modules.Conferences.Core;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Bootstraper")]
namespace Confab.Modules.Conferences.Api;

internal static class Extensions
{
    public static IServiceCollection AddConferences(this IServiceCollection services)
    {

        services.AddCore();
        return services;
    }

}