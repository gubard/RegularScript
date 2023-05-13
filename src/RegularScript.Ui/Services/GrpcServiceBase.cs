using System.Net.Http;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.Options;
using RegularScript.Ui.Modules;

namespace RegularScript.Ui.Services;

public abstract class GrpcServiceBase
{
    protected readonly IOptions<GrpcServiceOptions> options;

    protected GrpcServiceBase(IOptions<GrpcServiceOptions> options)
    {
        this.options = options;
    }

    protected GrpcWebHandler CreateHttpClientHandle()
    {
        var httpHandler = new HttpClientHandler();
        var result = new GrpcWebHandler(options.Value.Mode, httpHandler);

        return result;
    }
}