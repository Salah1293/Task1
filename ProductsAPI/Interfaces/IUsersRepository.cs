using ProductsAPI.Dtos;
using ProductsAPI.Models;

namespace ProductsAPI.Interfaces
{
    public interface IUsersRepository
    {
        public User Get(UserDto userDto);
    }
}
