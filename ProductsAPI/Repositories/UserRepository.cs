using Microsoft.EntityFrameworkCore;
using ProductsAPI.Dtos;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace ProductsAPI.Repositories
{
    public class UserRepository : IUsersRepository

    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        
        public User Get(UserDto userDto)
        {

            //User user = _context.Users.FirstOrDefault(o => o.Email.Equals(userDto.Email, StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userDto.Password));
            //return user;


            //User user = _context.Users.AsEnumerable().FirstOrDefault(o =>
            //            o.Email.Equals(userDto.Email, StringComparison.OrdinalIgnoreCase) &&
            //            o.Password == userDto.Password);
            //            return user;


            User user = _context.Users.FirstOrDefault(o =>
                         string.Equals(o.Email, userDto.Email, StringComparison.OrdinalIgnoreCase) &&
                         string.Equals(o.Password, userDto.Password));
                            return user;

        }
    }
}
