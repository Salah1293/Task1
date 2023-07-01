using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ProductsAPI.Dtos
{
    public class UserDto
    {

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }


        [Required]
        [MaxLength(100)]
        public string Password { get; set; }


    }
}
