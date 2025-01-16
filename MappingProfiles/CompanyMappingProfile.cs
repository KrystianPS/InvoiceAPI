using AutoMapper;
using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Models.CompanyModel;
using InvoiceAPI.Models.ContractorModel;

namespace InvoiceAPI.MappingProfiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyDto>()
               .ForMember(m => m.AddressLine1, c => c.MapFrom(s => s.Address.AddressLine1))
               .ForMember(m => m.AddressLine2, c => c.MapFrom(s => s.Address.AddressLine2))
               .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
               .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
               .ForMember(m => m.EmailAddress, c => c.MapFrom(s => s.Contact.EmailAddress))
               .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone));

            CreateMap<Company, CompanySummaryDto>()
               .ForMember(m => m.AddressLine1, c => c.MapFrom(s => s.Address.AddressLine1))
               .ForMember(m => m.AddressLine2, c => c.MapFrom(s => s.Address.AddressLine2))
               .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
               .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
               .ForMember(m => m.EmailAddress, c => c.MapFrom(s => s.Contact.EmailAddress))
               .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone));

            CreateMap<Contractor, ContractorSummaryDto>()
                 .ForMember(m => m.RelatedCompanyId, c => c.MapFrom(s => s.CompanyId));

            CreateMap<CreateCompanyDto, Company>()
                .ForMember(m => m.Address, c => c.MapFrom(dto => new CompanyAddressDetails
                {
                    AddressLine1 = dto.Address.AddressLine1,
                    AddressLine2 = dto.Address.AddressLine2,
                    City = dto.Address.City,
                    Country = dto.Address.Country,
                    PostalCode = dto.Address.PostalCode
                }))
                .ForMember(m => m.Contact, c => c.MapFrom(dto => new CompanyContactDetails
                {
                    EmailAddress = dto.Contact.EmailAddress,
                    Phone = dto.Contact.Phone
                }));
        }
    }
}
