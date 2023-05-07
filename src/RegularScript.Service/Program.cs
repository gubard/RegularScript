using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegularScript.Db.Contexts;
using RegularScript.Service.Profiles;
using RegularScript.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddTransient<MapperConfiguration>(
    _ => new MapperConfiguration(cfg => cfg.AddProfile<ServiceProfile>()));

builder.Services.AddTransient<IMapper>(sp => new Mapper(sp.GetService<MapperConfiguration>()));

builder.Services.AddDbContext<RegularScriptDbContext>((sp, options) =>
    options.UseNpgsql(sp.GetService<IConfiguration>()["PostgreSql:ConnectionString"]));

var app = builder.Build();
app.MapGrpcService<LanguageService>();

app.MapGet(
    pattern: "/",
    handler: () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();