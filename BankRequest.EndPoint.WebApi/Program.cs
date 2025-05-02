using BankRequest.DataAccess.Repository.Ef;
using BankRequest.Domain.AppService;
using BankRequest.Domain.Core.Contracts.AppService;
using BankRequest.Domain.Core.Contracts.Repository;
using BankRequest.Domain.Core.Contracts.Service;
using BankRequest.Domain.Service;
using BankRequest.Infra.SqlServer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IShebaRequestRepository, ShebaRequestRepository>();
builder.Services.AddScoped<IShebaRequestService, ShebaRequestService>();
builder.Services.AddScoped<IShebaRequestAppService, ShebaRequestAppService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankRequest API", Version = "v1" });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key ???? ?? Header ?? ????: X-API-KEY: {your_api_key} ????? ???",
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    if (path != null && path.StartsWith("/swagger")) 
    {
        await next();
        return;
    }

    if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("API Key is missing.");
        return;
    }

    var configuredApiKey = builder.Configuration.GetValue<string>("ApiKey");

    if (!string.Equals(extractedApiKey, configuredApiKey))
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Unauthorized client.");
        return;
    }

    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();