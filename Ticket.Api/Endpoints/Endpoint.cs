using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Ticket.Api.Common.Api;
using Ticket.Api.Endpoints.Identity;
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
            .MapGet("/", () => Results.Ok("Healthy"))
            .RequireAuthorization();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutIdentityEndpoint>()
            .MapEndpoint<GetIdentityRolesEndpoint>();

        endpoints.MapPost("v1/identity/register2", async ([FromBody] RegisterIdentityEndpoint.RegisterRequest register, UserManager<User> signManager) =>
        {
            User user = new()
            {
                Email = register.Email,
                UserName = register.UserName
            };

            var result = await signManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                return Results.BadRequest(result.Errors);
            }

            var token = await signManager.GenerateEmailConfirmationTokenAsync(user);
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            var confirmationLink = $"http://localhost:5062/confrim-email?email={register.Email}&code={code}";

            return Results.Created();
        });


    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }

    private class RegisterIdentityEndpoint
    {
        public class RegisterRequest
        {
            public string UserName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public class LoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }



    }
}
