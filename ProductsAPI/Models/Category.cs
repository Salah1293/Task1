using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }


        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string ArabicName { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string EnglishName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        public bool State { get; set; } = true;

        public string Creation_user_id { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreationDate { get; set; }


        public string Update_user_id { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            CreationDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }


    }
}
