namespace InvoiceAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }


        public required decimal UnitPriceNet { get; set; }
        public required VatRate VatRate { get; set; }
        public required int VarRateId { get; set; }
        public decimal VatAmount { get; set; }
        public decimal UnitPriceGross { get; set; }

    }
}
