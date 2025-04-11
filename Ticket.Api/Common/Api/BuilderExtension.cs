using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ticket.Api.Data;
using Ticket.Api.Models;
using Ticket.Core;

namespace Ticket.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder
            .Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public static void AddDocumentationSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
        builder.Services.AddAuthorization();
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<AppDbContext>(x => { x.UseSqlServer(Configuration.ConnectionString); });

        builder.Services
            .AddIdentityCore<User>(x => x.SignIn.RequireConfirmedAccount = true)
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();

        // builder.Services.AddIdentity<User, IdentityRole<long>>(x => x.SignIn.RequireConfirmedAccount = true)
        //     .AddEntityFrameworkStores<AppDbContext>();
    }
}
