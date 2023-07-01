using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ProductsAPI.Models
{
    public class User
    { 

        public string UserId { get; set; }


       // public bool RememberMe { get; set; }


        
        //public string Username { get; set; }

        [MaxLength(150)]
        public string ArabicName { get; set; }


        [MaxLength(150)]
        public string EnglishName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }


        [Required]
        [MaxLength(100)]
        public string Password { get; set; }


        [MaxLength(20)]
        public string Mobile { get; set; }

       


    }
}
