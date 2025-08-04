using Confab.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Http;

namespace Confab.Shared.Infrastructure.Context;

internal interface IContextFactory
{
    IContext Create();
}

internal class ContextFactory(IHttpContextAccessor httpContextAccessor) : IContextFactory
{
    public IContext Create()
    {
        var httpContext = httpContextAccessor.HttpContext;
        
        return httpContext is null ? Context.Empty : new Context(httpContext);
    }
}