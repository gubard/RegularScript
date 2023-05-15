using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RegularScript.Db.Contexts;
using RegularScript.Service.GrpcServices;
using RegularScript.Service.Interfaces;
using RegularScript.Service.Models;
using RegularScript.Service.Profiles;
using RegularScript.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMapper>(sp => new Mapper(sp.GetService<MapperConfiguration>()));
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IScriptRepository, ScriptRepository>();
builder.Services.AddGrpc();
builder.Services.AddOptions<ScriptRepositoryOptions>(ScriptRepositoryOptions.ConfigurationPath);
builder.Logging.AddConsole();

builder.Services.AddScoped<MapperConfiguration>(
    _ => new MapperConfiguration(cfg => cfg.AddProfile<ServiceProfile>())
);

builder.Services.AddDbContext<RegularScriptDbContext>(
    (sp, options) =>
    {
        var configuration = sp.GetService<IConfiguration>() ?? throw new NullReferenceException();
        options.UseNpgsql(configuration["PostgreSql:ConnectionString"]);
    }
);

builder.Services.AddCors(
    o => o.AddPolicy(
        "AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
        }
    )
);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseGrpcWeb(
    new GrpcWebOptions
    {
        DefaultEnabled = true
    }
);
app.UseCors("AllowAll");

app.MapGrpcService<LanguageService>().EnableGrpcWeb();
app.MapGrpcService<ScriptService>().EnableGrpcWeb();

app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();