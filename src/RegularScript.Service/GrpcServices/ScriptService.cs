using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf;
using Grpc.Core;
using GrpcClient.Script;
using RegularScript.Service.Interfaces;
using RegularScript.Service.Models;

namespace RegularScript.Service.GrpcServices;

public class ScriptService : ScriptServiceApi.ScriptServiceApiBase
{
    private readonly IMapper mapper;
    private readonly IScriptRepository scriptRepository;

    public ScriptService(IScriptRepository scriptRepository, IMapper mapper)
    {
        this.scriptRepository = scriptRepository;
        this.mapper = mapper;
    }

    public override async Task<GetRootScriptsReply> GetRootScripts(
        GetRootScriptsRequest request,
        ServerCallContext context
    )
    {
        var languageId = new Guid(request.LanguageId.ToByteArray());
        var scripts = await scriptRepository.GetRootScriptsAsync(languageId);
        var reply = new GetRootScriptsReply();
        reply.Scripts.AddRange(scripts.Select(x => mapper.Map<ScriptApi>(x)));

        return reply;
    }

    public override async Task<AddRootScriptReply> AddRootScript(AddRootScriptRequest request, ServerCallContext context)
    {
        var parameters = mapper.Map<AddRootScriptParameters>(request);
        var id = await scriptRepository.AddRootScriptAsync(parameters);

        return new AddRootScriptReply
        {
            ScriptId = ByteString.CopyFrom(id.ToByteArray())
        };
    }

    public override async Task<AddScriptReply> AddScript(AddScriptRequest request, ServerCallContext context)
    {
        var parameters = mapper.Map<AddScriptParameters>(request);
        var id = await scriptRepository.AddScriptAsync(parameters);

        return new AddScriptReply
        {
            ScriptId = ByteString.CopyFrom(id.ToByteArray())
        };
    }
}