using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProductsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }


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
        [MaxLength(1000)]
        public string Description { get; set; }


        [Required]
        [MaxLength(100)]
        public string Manufacturer { get; set; }


        public bool State { get; set; } = true;


        public string Creation_user_id { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreationDate { get; set; }


        public string Update_user_id { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        
        public Category Category { get; set; }


        public Product()
        {
            CreationDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}

