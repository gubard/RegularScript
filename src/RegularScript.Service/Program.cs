using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegularScript.Db.Contexts;
using RegularScript.Service.Profiles;
using RegularScript.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMapper>(sp => new Mapper(sp.GetService<MapperConfiguration>()));
builder.Services.AddGrpc(options => options.EnableDetailedErrors = true);
builder.Logging.AddConsole();

builder.Services.AddTransient<MapperConfiguration>(
    _ => new MapperConfiguration(cfg => cfg.AddProfile<ServiceProfile>()));

builder.Services.AddDbContext<RegularScriptDbContext>((sp, options) =>
{
    var configuration = sp.GetService<IConfiguration>() ?? throw new NullReferenceException();
    options.UseNpgsql(configuration["PostgreSql:ConnectionString"]);
});

builder.Services.AddCors(setupAction =>
    setupAction.AddPolicy("AllowAll",
        policy =>
            policy.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()));

var app = builder.Build();
app.UseHsts();
app.UseCors("AllowAll");
app.UseRouting();

app.UseGrpcWeb(new GrpcWebOptions()
{
    DefaultEnabled = true
});

app.MapGrpcService<LanguageService>().EnableGrpcWeb();

app.MapGet(
    pattern: "/",
    handler: () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();