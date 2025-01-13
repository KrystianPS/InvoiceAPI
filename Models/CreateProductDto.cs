namespace InvoiceAPI.Models
{
    public class CreateProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal UnitPriceNet { get; set; }
        public string? ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
        public int CompanyId { get; set; }

    }
}
