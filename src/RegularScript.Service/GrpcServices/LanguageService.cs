using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using GrpcClient.Language;
using RegularScript.Service.Interfaces;

namespace RegularScript.Service.GrpcServices;

public class LanguageService : LanguageServiceApi.LanguageServiceApiBase
{
    private readonly ILanguageRepository languageRepository;
    private readonly IMapper mapper;

    public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
    {
        this.languageRepository = languageRepository;
        this.mapper = mapper;
    }

    public override async Task<GetAllReply> GetAll(GetAllRequest request, ServerCallContext context)
    {
        var languages = await languageRepository.GetAllAsync();
        var reply = new GetAllReply();
        reply.Languages.AddRange(languages.Select(x => mapper.Map<LanguageApi>(x)).ToArray());

        return reply;
    }

    public override async Task<GetSupportedReply> GetSupported(GetSupportedRequest request, ServerCallContext context)
    {
        var languages = await languageRepository.GetSupportedAsync();
        var reply = new GetSupportedReply();
        reply.Languages.AddRange(languages.Select(x => mapper.Map<LanguageApi>(x)).ToArray());

        return reply;
    }
}