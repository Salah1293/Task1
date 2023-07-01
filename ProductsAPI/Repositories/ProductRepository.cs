using Microsoft.EntityFrameworkCore;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : IProductsRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId = 0)
        {
            return await _context.Products
                .Where(p => p.Category.CategoryId == categoryId || categoryId == 0 &&  p.State == true)
                .Include(p => p.Category)
                .ToListAsync();
        }



        public async Task<Product> Add(Product product)
        {
            await _context.AddAsync(product);

            return product;
        }




        public Product Delete(Product product)
        {
            product.State = false;

            return product;
        }




        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id && p.State == true)
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }





        public Product Update(Product product)
        {
            _context.Update(product);

            return product;
        }




        public async Task<IEnumerable<Product>> Search(string productName = null, int categoryId = 0)
        {
            return await _context.Products
                .Where(p => p.ArabicName == productName || p.EnglishName == productName || productName == null &&  p.State == true)
                .Where(p => p.Category.CategoryId == categoryId || categoryId == 0)
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
