using Microsoft.AspNetCore.Identity;
using ProductsAPI.Helpers;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using ProductsAPI.Repositories;
using System.Diagnostics.Metrics;

namespace ProductsAPI
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public IProductsRepository Products { get; private set; }

        public ICategoriesRepository Category { get; private set; }

        public IUsersRepository Users { get; private set; }

       

        public UnitOfWork(ApplicationDbContext context)
            
        {
            _context = context;
      
            Products = new ProductRepository(_context);

            Category = new CategoryRepository(_context);

            Users = new UserRepository(_context);

           

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
