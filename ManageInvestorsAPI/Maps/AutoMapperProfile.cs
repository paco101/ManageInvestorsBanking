using AutoMapper;
using ManageInvestors.Models;
using Models.DTOs;

namespace ManageInvestorsAPI.Maps
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Fund, FundDTO>().ReverseMap();
            CreateMap<Investment, InvestmentDTO>().ReverseMap();
            CreateMap<Investor, InvestorDTO>()
            .ForMember(dest => dest.Fullname, opt => opt.Ignore()) // Ignoring Fullname in DTO
            .ReverseMap()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            // Add more mappings as needed
        }
    }
}