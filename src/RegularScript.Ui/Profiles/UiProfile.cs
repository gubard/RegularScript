using System;
using AutoMapper;
using Google.Protobuf;
using GrpcClient.Language;
using GrpcClient.Script;
using RegularScript.Core.Common.Extensions;
using RegularScript.Ui.Models;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Profiles;

public class UiProfile : Profile
{
    public UiProfile()
    {
        CreateMap<Script, ScriptNodeNotify>();

        CreateMap<ScriptApi, Script>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => new Guid(src.Id.ToByteArray())));
        CreateMap<LanguageApi, Language>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => new Guid(src.Id.ToByteArray())));
        CreateMap<Language, LanguageNotify>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => new Guid(src.Id.ToByteArray())));
        CreateMap<AddRootScriptParameters, AddRootScriptRequest>()
            .ForMember(x => x.LanguageId, opt => opt.MapFrom(src => ByteString.CopyFrom(src.LanguageId.ToByteArray())));

        CreateMap<AddScriptParameters, AddScriptRequest>()
            .ForMember(x => x.LanguageId, opt => opt.MapFrom(src => ByteString.CopyFrom(src.LanguageId.ToByteArray())))
            .ForMember(
                x => x.ParentScriptId,
                opt => opt.MapFrom(src => ByteString.CopyFrom(src.ParentId.ToByteArray()))
            );

        CreateMap<AddScriptViewModel, AddRootScriptParameters>()
            .ForMember(
                x => x.LanguageId,
                opt => opt.MapFrom(src => src.SelectedLanguage.ThrowIfNull(nameof(src.SelectedLanguage)).Id)
            );

        CreateMap<AddScriptViewModel, AddScriptParameters>()
            .ForMember(
                x => x.LanguageId,
                opt => opt.MapFrom(src => src.SelectedLanguage.ThrowIfNull(nameof(src.SelectedLanguage)).Id)
            )
            .ForMember(
                x => x.ParentId,
                opt => opt.MapFrom(src => src.Parent.ThrowIfNull(nameof(src.Parent)).Id)
            );
    }
}