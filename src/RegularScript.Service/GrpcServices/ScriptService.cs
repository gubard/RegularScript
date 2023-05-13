using AutoMapper;
using Grpc.Core;
using GrpcClient.Script;
using RegularScript.Service.Services;

namespace RegularScript.Service.GrpcServices;

public class ScriptService : ScriptServiceApi.ScriptServiceApiBase
{
    private readonly ScriptRepository scriptRepository;
    private readonly IMapper mapper;

    public ScriptService(ScriptRepository scriptRepository, IMapper mapper)
    {
        this.scriptRepository = scriptRepository;
        this.mapper = mapper;
    }

    public override async Task<GetRootScriptsReply> GetRootScripts(
        GetRootScriptsRequest request,
        ServerCallContext context)
    {
        var languageId = new Guid(request.LanguageId.ToByteArray());
        var scripts = await scriptRepository.GetRootScriptsAsync(languageId);
        var reply = new GetRootScriptsReply();
        reply.Scripts.AddRange(scripts.Select(x => mapper.Map<ScriptApi>(x)));

        return reply;
    }
}