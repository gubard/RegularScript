using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrpcClient.Language;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Services;

public class LanguageService : GrpcServiceBase, ILanguageService
{
    private readonly LanguageServiceApi.LanguageServiceApiClient languageServiceApiClient;
    private readonly IMapper mapper;

    public LanguageService(GrpcServiceOptions options, IMapper mapper) : base(options)
    {
        this.mapper = mapper;
        languageServiceApiClient = new LanguageServiceApi.LanguageServiceApiClient(grpcChannel);
    }

    public async Task<IEnumerable<Language>> GetAllAsync()
    {
        var request = new GetAllRequest();
        var reply = await languageServiceApiClient.GetAllAsync(request);

        return reply.Languages.Select(x => mapper.Map<Language>(x)).ToArray();
    }

    public async Task<IEnumerable<Language>> GetSupportedAsync()
    {
        var request = new GetSupportedRequest();
        var reply = await languageServiceApiClient.GetSupportedAsync(request);

        return reply.Languages.Select(x => mapper.Map<Language>(x)).ToArray();
    }
}