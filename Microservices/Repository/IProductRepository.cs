using DataModels.models;

namespace Microservices.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(string id, Product product);
        Task DeleteProductAsync(string id);
        Task<bool> ProductExistsAsync(string id);
    }
}