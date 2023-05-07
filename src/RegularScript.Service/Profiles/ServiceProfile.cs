using AutoMapper;
using Google.Protobuf;
using GrpcClient.Language;
using RegularScript.Db.Entities;

namespace RegularScript.Service.Profiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Language, LanguageApi>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => ByteString.CopyFrom(src.Id.ToByteArray())));
    }
}