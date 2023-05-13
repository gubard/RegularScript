using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf;
using Grpc.Net.Client;
using GrpcClient.Script;
using Microsoft.Extensions.Options;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Modules;
using Script = RegularScript.Ui.Models.Script;

namespace RegularScript.Ui.Services;

public class ScriptService : GrpcServiceBase, IScriptService
{
    private readonly IMapper mapper;

    public ScriptService(IOptions<GrpcServiceOptions> options, IMapper mapper) : base(options)
    {
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Script>> GetRootScriptsAsync(Guid languageId)
    {
        using var httpHandler = CreateHttpClientHandle();
        var channelOptions = new GrpcChannelOptions { HttpHandler = httpHandler };
        var channel = GrpcChannel.ForAddress(options.Value.Url, channelOptions);
        var client = new ScriptServiceApi.ScriptServiceApiClient(channel);

        var request = new GetRootScriptsRequest
        {
            LanguageId = ByteString.CopyFrom(languageId.ToByteArray())
        };
        
        var reply = await client.GetRootScriptsAsync(request);
        await channel.ShutdownAsync();

        return reply.Scripts.Select(x => mapper.Map<Script>(x)).ToArray();
    }
}