using System;
using AutoMapper;
using Google.Protobuf;
using GrpcClient.Language;
using GrpcClient.Script;
using RegularScript.Db.Entities;
using RegularScript.Service.Models;

namespace RegularScript.Service.Profiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Script, ScriptApi>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => ByteString.CopyFrom(src.Id.ToByteArray())));
        CreateMap<LanguageDb, LanguageApi>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => ByteString.CopyFrom(src.Id.ToByteArray())));
        CreateMap<AddRootScriptRequest, AddRootScriptParameters>()
            .ForMember(x => x.LanguageId, opt => opt.MapFrom(src => new Guid(src.LanguageId.ToByteArray())));
        CreateMap<AddScriptRequest, AddScriptParameters>()
            .ForMember(x => x.LanguageId, opt => opt.MapFrom(src => new Guid(src.LanguageId.ToByteArray())))
            .ForMember(x => x.ParentId, opt => opt.MapFrom(src => new Guid(src.ParentScriptId.ToByteArray())));
    }
}