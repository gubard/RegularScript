using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf;
using GrpcClient.Script;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Services;

public class ScriptService : GrpcServiceBase, IScriptService
{
    private readonly IMapper mapper;
    private readonly ScriptServiceApi.ScriptServiceApiClient scriptServiceApiClient;

    public ScriptService(GrpcServiceOptions options, IMapper mapper) : base(options)
    {
        this.mapper = mapper;
        scriptServiceApiClient = new ScriptServiceApi.ScriptServiceApiClient(grpcChannel);
    }

    public async Task<IEnumerable<Script>> GetRootScriptsAsync(Guid languageId)
    {
        var request = new GetRootScriptsRequest
        {
            LanguageId = ByteString.CopyFrom(languageId.ToByteArray())
        };

        var reply = await scriptServiceApiClient.GetRootScriptsAsync(request);

        return reply.Scripts.Select(x => mapper.Map<Script>(x)).ToArray();
    }
}