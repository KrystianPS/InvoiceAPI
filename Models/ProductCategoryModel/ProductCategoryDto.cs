namespace InvoiceAPI.Models.ProductCategoryModel
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
