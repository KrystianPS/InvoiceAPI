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
            .ForMember(m => m.InvoiceItems, s => s.MapFrom(ent => ent.InvoiceItems));

            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(m => m.IssueDate, s => s.MapFrom(_ => DateTime.UtcNow))
                .ForMember(m => m.InvoiceItems, s => s.Ignore())
                .ForMember(m => m.TotalNet, s => s.Ignore())
                .ForMember(m => m.TotalVatAmount, s => s.Ignore())
                .ForMember(m => m.TotalGross, s => s.Ignore());

            CreateMap<InvoiceItem, InvoiceItemDto>();


        }

    }
}
