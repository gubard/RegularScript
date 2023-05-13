using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Net.Client;
using GrpcClient.Language;
using Microsoft.Extensions.Options;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;
using RegularScript.Ui.Modules;

namespace RegularScript.Ui.Services;

public class LanguageService : GrpcServiceBase, ILanguageService
{
    private readonly IMapper mapper;

    public LanguageService(IOptions<GrpcServiceOptions> options, IMapper mapper) : base(options)
    {
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Language>> GetAllAsync()
    {
        using var httpHandler = CreateHttpClientHandle();
        var channelOptions = new GrpcChannelOptions { HttpHandler = httpHandler };
        var channel = GrpcChannel.ForAddress(options.Value.Url, channelOptions);
        var client = new LanguageServiceApi.LanguageServiceApiClient(channel);
        var request = new GetAllRequest();
        var reply = await client.GetAllAsync(request);
        await channel.ShutdownAsync();

        return reply.Languages.Select(x => mapper.Map<Language>(x)).ToArray();
    }

    public async Task<IEnumerable<Language>> GetSupportedAsync()
    {
        using var httpHandler = CreateHttpClientHandle();
        var channelOptions = new GrpcChannelOptions { HttpHandler = httpHandler };
        var channel = GrpcChannel.ForAddress(options.Value.Url, channelOptions);
        var client = new LanguageServiceApi.LanguageServiceApiClient(channel);
        var request = new GetSupportedRequest();
        var reply = await client.GetSupportedAsync(request);
        await channel.ShutdownAsync();

        return reply.Languages.Select(x => mapper.Map<Language>(x)).ToArray();
    }
}