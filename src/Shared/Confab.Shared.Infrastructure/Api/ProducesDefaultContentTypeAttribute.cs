using Microsoft.AspNetCore.Mvc;

namespace Confab.Shared.Infrastructure.Api;

public class ProducesDefaultContentTypeAttribute : ProducesAttribute
{
    public ProducesDefaultContentTypeAttribute() : base("application/json")
    {
    }

    public ProducesDefaultContentTypeAttribute(params string[] additionalContentTypes) : base("application/json", additionalContentTypes)
    {
    }
}