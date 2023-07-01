using Microsoft.AspNetCore.Identity;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
        ICategoriesRepository Category { get; }

        IUsersRepository Users { get; }


        int Complete();
    }
}
