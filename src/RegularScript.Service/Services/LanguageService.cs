using AutoMapper;
using Grpc.Core;
using GrpcClient.Language;
using Microsoft.EntityFrameworkCore;
using RegularScript.Db.Contexts;
using RegularScript.Db.Entities;

namespace RegularScript.Service.Services;

public class LanguageService : LanguageServiceApi.LanguageServiceApiBase
{
    private readonly RegularScriptDbContext dbContext;
    private readonly IMapper mapper;

    public LanguageService(RegularScriptDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public override async Task<GetAllReply> GetAll(GetAllRequest request, ServerCallContext context)
    {
        var languages = await dbContext.Set<Language>().ToArrayAsync();
        var reply = new GetAllReply();
        reply.Languages.AddRange(languages.Select(x => mapper.Map<LanguageApi>(x)).ToArray());

        return reply;
    }
}