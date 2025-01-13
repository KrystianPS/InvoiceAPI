using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;

namespace InvoiceAPI.MappingProfiles
{
    public class InvoiceApiMappingProfile : Profile
    {
        public InvoiceApiMappingProfile()
        {
            CreateMap<Contractor, ContractorDto>()
                .ForMember(m => m.AddressLine1, c => c.MapFrom(s => s.Address.AddressLine1))
                .ForMember(m => m.AddressLine2, c => c.MapFrom(s => s.Address.AddressLine2))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.EmailAddress, c => c.MapFrom(s => s.Contact.EmailAddress))
                .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone));

            CreateMap<Company, CompanyDto>()
                .ForMember(m => m.AddressLine1, c => c.MapFrom(s => s.Address.AddressLine1))
                .ForMember(m => m.AddressLine2, c => c.MapFrom(s => s.Address.AddressLine2))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.EmailAddress, c => c.MapFrom(s => s.Contact.EmailAddress))
                .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone)); ;


            CreateMap<Contractor, ContractorSummaryDto>()
                 .ForMember(m => m.RelatedCompanyId, c => c.MapFrom(s => s.CompanyId));

        }
    }
}
