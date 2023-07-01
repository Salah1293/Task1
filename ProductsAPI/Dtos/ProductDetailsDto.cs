using ProductsAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Dtos
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }


      
        public string ArabicName { get; set; }


        public string EnglishName { get; set; }


      
        public double Price { get; set; }


      
        public string Description { get; set; }


        public string Manufacturer { get; set; }



        public int Creation_user_id { get; set; }


        
        public DateTime? CreationDate { get; set; }


        public int Update_user_id { get; set; }


        public DateTime? ModifiedDate { get; set; }


       
        public int CategoryId { get; set; }


        public string CategoryArabicName { get; set; }


        public string CategoryEnglishName { get; set; }



    }
}
