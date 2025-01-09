namespace InvoiceAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }


        public required decimal UnitPriceNet { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
