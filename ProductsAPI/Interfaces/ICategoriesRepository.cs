using ProductsAPI.Models;

namespace ProductsAPI.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category Category);
        Category Update(Category Category);
        Category Delete(Category Category);
        
    }
}
