using AutoMapper;
using Pizzeria_Ordering_System.DataTransfer;

namespace Pizzeria_Ordering_System.Persistence.Mapper
{
    public class QueryProfile : Profile
    {
        /// <summary>
        /// Query Profile.
        /// </summary>
        public QueryProfile()
        {
            CreateMap<Pizza, Contract.Pizza>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Constituents, Contract.Constituents>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
