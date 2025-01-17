using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.DtoModels.ProductModel
{
    public class UpdateProductDto
    {

        public string? Description { get; set; }
        [Required]
        public decimal UnitPriceNet { get; set; }

    }
}
