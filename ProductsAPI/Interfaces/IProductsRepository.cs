using ProductsAPI.Models;

namespace ProductsAPI.Interfaces
{
    public interface IProductsRepository
    {
       
        Task<IEnumerable<Product>> GetByCategoryId(int categoryId = 0);
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);
        Task<IEnumerable<Product>> Search(string productName = null, int CategoryId = 0);
    }
}
