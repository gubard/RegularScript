using System;
using AutoMapper;
using GrpcClient.Language;
using RegularScript.Ui.Models;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Profiles;

public class UiProfile : Profile
{
    public UiProfile()
    {
        CreateMap<LanguageApi, Language>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => new Guid(src.Id.ToByteArray())));
        CreateMap<Language, LanguageNotify>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => new Guid(src.Id.ToByteArray())));
    }
}