using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Dtos
{
    public class CategoryDto
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }


        //public bool State { get; set; } = true;


    }
}
