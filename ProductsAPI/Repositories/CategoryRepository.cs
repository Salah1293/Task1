using Microsoft.EntityFrameworkCore;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public class CategoryRepository : ICategoriesRepository
    {

        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<Category> Add(Category Category)
        {
            await _context.AddAsync(Category);

            return Category;
        }




        public  Category Delete(Category Category)
        {

            Category.State = false;

            return Category;
        }




        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories
                .Where(c => c.State == true)
                .ToListAsync();
        }




        public Category Update(Category Category)
        {
            _context.Update(Category);

            return Category;
        }

        
        public async Task<Category> GetById(int id)
        {
            return await _context.Categories
                .Where(c => c.CategoryId == id || c.State == true)
                .SingleOrDefaultAsync(p => p.CategoryId == id);
        }
    }
}
