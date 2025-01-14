using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.ProductCategoryModel
{
    public class CreateProductCategoryDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
