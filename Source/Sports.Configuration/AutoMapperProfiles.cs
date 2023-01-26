using AutoMapper;
using Sports.Data.Dtos;
using Sports.Data.Entities;

namespace Sports.Configuration
{

    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            _ = CreateMap<Product, ProductViewDto>().ReverseMap();

            _ = CreateMap<ProductAddDto, Product>().ReverseMap();

            _ = CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.UseDestinationValue())
                .ReverseMap();
        }

    }

}