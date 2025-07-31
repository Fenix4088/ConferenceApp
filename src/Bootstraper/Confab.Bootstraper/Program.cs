using Confab.Bootstraper;
using Confab.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var assemblies = ModuleLoader.LoadAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);

// Reflection registers all modules
foreach (var module in modules)
{
    module.Register(builder.Services);
}

builder.Services
    .AddInfrastructure();

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