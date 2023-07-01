using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Dtos
{
    public class ProductDto
    {

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string ArabicName { get; set; }


        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string EnglishName { get; set; }


        [Required]
        public double Price { get; set; }


        [Required]
        public string Description { get; set; }


        //public bool State { get; set; } = true;


        public string Manufacturer { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
