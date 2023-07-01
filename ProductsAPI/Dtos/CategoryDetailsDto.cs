using ProductsAPI.Models;

namespace ProductsAPI.Dtos
{
    public class CategoryDetailsDto
    {

        public int CategoryId { get; set; }



        public string ArabicName { get; set; }


        public string EnglishName { get; set; }


        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }


        public int Creation_user_id { get; set; }


        public DateTime? CreationDate { get; set; }


        public int Update_user_id { get; set; }


        public DateTime? ModifiedDate { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
