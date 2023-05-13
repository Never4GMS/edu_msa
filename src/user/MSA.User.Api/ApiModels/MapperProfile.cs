using AutoMapper;

namespace MSA.User.Api.ApiModels
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.User, ApiModels.User>()
                .ReverseMap();
        }
    }
}
