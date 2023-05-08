using AutoMapper;

namespace NzWalks.api.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            //converting the domain model to DTO model, mapping data from the source to the destionation
            CreateMap<Models.Domain.Regions, Models.DTO.Regions>()
               // .ForMember(dest => dest.id, options => options.MapFrom(src => src.id)); //help - gpt
               .ReverseMap();

        }
    }
}
