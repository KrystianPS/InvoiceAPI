using AutoMapper;
using InvoiceAPI.DtoModels.InvoiceModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Models.InvoiceModel;

namespace InvoiceAPI.MappingProfiles
{
    public class InvoiceMappingProfile : Profile
    {

        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(m => m.Company, s => s.MapFrom(ent => ent.Company))
                .ForMember(m => m.Contractor, s => s.MapFrom(ent => ent.Contractor))
                .ForMember(m => m.InvoiceItems, s => s.MapFrom(ent => ent.InvoiceItems))
                .ReverseMap();


            CreateMap<InvoiceItem, InvoiceItemDto>().ReverseMap();

            //CreateMap<Contractor, ContractorDto>().ReverseMap();

            CreateMap<Company, CompanySummaryDto>()
              .ForMember(m => m.AddressLine1, c => c.MapFrom(s => s.Address.AddressLine1))
              .ForMember(m => m.AddressLine2, c => c.MapFrom(s => s.Address.AddressLine2))
              .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
              .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
              .ForMember(m => m.EmailAddress, c => c.MapFrom(s => s.Contact.EmailAddress))
              .ForMember(m => m.Phone, c => c.MapFrom(s => s.Contact.Phone));

        }

    }
}
