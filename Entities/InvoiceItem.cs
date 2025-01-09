namespace InvoiceAPI.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quaitity { get; set; }
        public decimal ItemPriceNet { get; set; }
        public decimal ItemVatAmount { get; set; }
        public decimal ItemPriceGross { get; set; }
    }
}