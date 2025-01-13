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
                .ForMember(m => m.AddressLine1, c => c.MapFrom(s => s.Address.AddressLine1))
                .ForMember(m => m.AddressLine2, c => c.MapFrom(s => s.Address.AddressLine2))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.EmailAddress, c => c.MapFrom(s => s.Contact.EmailAddress))
                .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone));

            CreateMap<CreateContractorDto, Contractor>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.TIN, opt => opt.MapFrom(src => src.TIN))
             .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new ContractorAddressDetails
            {
                AddressLine1 = src.Address.AddressLine1,
                AddressLine2 = src.Address.AddressLine2,
                City = src.Address.City,
                PostalCode = src.Address.PostalCode,
                Country = src.Address.Country
            }))
            .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => new ContractorContactDetails
            {
                Phone = src.Contact.Phone,
                EmailAddress = src.Contact.EmailAddress
            }));





        }
    }
}