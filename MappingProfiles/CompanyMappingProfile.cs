using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;

namespace InvoiceAPI.MappingProfiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(m => m.AddresLine1, c => c.MapFrom(s => s.Address.AddressLine1))
                .ForMember(m => m.AddresLine2, c => c.MapFrom(s => s.Address.AddressLine2))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.EmailAdress, c => c.MapFrom(s => s.Contact.EmailAddress))
                .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone));

            CreateMap<Contractor, ContractorSummaryDto>();

        }
    }
}
