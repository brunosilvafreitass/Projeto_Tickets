using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Ticket.Api.Common.Api;
using Ticket.Api.Models;

namespace Ticket.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .WithName("HealthCheck")
            .MapGet("/", () => Results.Ok("Healthy"));

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();
    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }

}
