using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegularScript.Db.Contexts;
using RegularScript.Service.Profiles;
using RegularScript.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMapper>(sp => new Mapper(sp.GetService<MapperConfiguration>()));
builder.Services.AddGrpc();
builder.Logging.AddConsole();

builder.Services.AddTransient<MapperConfiguration>(
    _ => new MapperConfiguration(cfg => cfg.AddProfile<ServiceProfile>()));

builder.Services.AddDbContext<RegularScriptDbContext>((sp, options) =>
{
    var configuration = sp.GetService<IConfiguration>() ?? throw new NullReferenceException();
    options.UseNpgsql(configuration["PostgreSql:ConnectionString"]);
});

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseGrpcWeb(new GrpcWebOptions {DefaultEnabled = true});
app.UseCors("AllowAll");

app.MapGrpcService<LanguageService>().EnableGrpcWeb();

app.MapGet(
    pattern: "/",
    handler: () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();