using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.ProductModel
{
    public class CreateProductDto
    {

        [Required]
        [MaxLength(25)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public required decimal UnitPriceNet { get; set; }
        public string? ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
        public int CompanyId { get; set; }

    }
}
