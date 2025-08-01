using Confab.Bootstraper;
using Confab.Shared.Infrastructure;
using Confab.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureModules();

var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);

// Reflection registers all modules
foreach (var module in modules)
{
    module.Register(builder.Services);
}

builder.Services
    .AddInfrastructure(assemblies, modules);

var app = builder.Build();

app.UseInfrastructure();

// Reflections use each module middleware
foreach (var module in modules)
{
    module.Use(app);
}


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();