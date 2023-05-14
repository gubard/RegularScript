using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Services;

public abstract class GrpcServiceBase : IAsyncDisposable, IDisposable
{
    protected readonly GrpcChannel grpcChannel;
    private readonly GrpcChannelOptions grpcChannelOptions;
    private readonly GrpcWebHandler grpcWebHandler;
    private readonly HttpClientHandler httpClientHandler;
    private readonly GrpcServiceOptions options;

    protected GrpcServiceBase(GrpcServiceOptions options)
    {
        this.options = options;
        httpClientHandler = new HttpClientHandler();
        grpcWebHandler = new GrpcWebHandler(options.Mode, httpClientHandler);
        grpcChannelOptions = new GrpcChannelOptions { HttpHandler = grpcWebHandler };
        grpcChannel = GrpcChannel.ForAddress(options.Host, grpcChannelOptions);
    }

    public virtual async ValueTask DisposeAsync()
    {
        Dispose();
        await grpcChannel.ShutdownAsync();
    }

    public virtual void Dispose()
    {
        httpClientHandler.Dispose();
        grpcWebHandler.Dispose();
        grpcChannel.Dispose();
    }
}