using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;

namespace InvoiceAPI.MappingProfiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {


            CreateMap<Contractor, ContractorDto>();


            CreateMap<Contractor, ContractorSummaryDto>()
                .ForMember(dest => dest.ContractorId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CompanyAddressDetails, CompanyAddressDetailsDto>();

            CreateMap<CompanyContactDetails, CompanyContactDetailsDto>();

        }
    }
}
