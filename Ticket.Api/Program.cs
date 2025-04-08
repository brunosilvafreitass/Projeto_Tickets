using Scalar.AspNetCore;
using Ticket.Api.Common.Api;
using Ticket.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
// builder.AddCrossOrigin();
builder.AddDocumentationSwagger();
// builder.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger();

    app.MapScalarApiReference();
}

app.MapEndpoints();

app.Run();
