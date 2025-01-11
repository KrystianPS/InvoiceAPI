using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;

namespace InvoiceAPI.MappingProfiles
{
    public class ContractorMappingProfile : Profile
    {
        public ContractorMappingProfile()
        {
            CreateMap<Contractor, ContractorDto>()
                .ForMember(m => m.AddresLine1, c => c.MapFrom(s => s.Address.AddressLine1))
                .ForMember(m => m.AddresLine2, c => c.MapFrom(s => s.Address.AddressLine2))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City));
        }
    }
}
