using System.ComponentModel.DataAnnotations;

namespace MVCWebshop.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [Display(Name = "PRODUCT")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "STATUS")]
        public int ProductStatus { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid decimal Number")]
        [Display(Name = "PRICE")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "UNITS IN STOCK")]
        public int ProductUnitsStock { get; set; }
    }
}