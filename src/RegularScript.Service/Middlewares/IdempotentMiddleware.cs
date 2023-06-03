using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using RegularScript.Core.Common.Extensions;
using RegularScript.Service.Attributes;
using RegularScript.Service.Exceptions;
using RegularScript.Service.Interfaces;

namespace RegularScript.Service.Middlewares;

public class IdempotentMiddleware
{
    private const string HeaderKey = "X-Idempotent-Id";
    private readonly RequestDelegate next;

    public IdempotentMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext httpContext, IIdempotentService idempotentService)
    {
        var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<IdempotentAttribute>();

        if (attribute is null)
        {
            await next(httpContext);

            return;
        }

        if (!httpContext.Request.Headers.TryGetValue(HeaderKey, out var values))
        {
            throw new HeaderNotFoundException(HeaderKey);
        }

        values.ThrowIfEmpty();
        values.Count.ThrowIfNotEquals(1);
        var id = Guid.Parse(values[0].ThrowIfNullOrWhiteSpace());
        await using var stream = await idempotentService.GetOrNullAsync(id);

        if (stream is not null)
        {
            await stream.CopyToAsync(httpContext.Response.Body);

            return;
        }

        await next(httpContext);
        await idempotentService.AddAsync(id, httpContext.Response.Body);
    }
}