using DataModels.models;
using MongoDB.Driver;

namespace Microservices.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public ProductRepository(IMongoDatabase database)
        {
            _productsCollection = database.GetCollection<Product>("Products");
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            return await _productsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _productsCollection.InsertOneAsync(product);
            return product;
        }

        public async Task<Product> UpdateProductAsync(string id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            await _productsCollection.ReplaceOneAsync(filter, product);
            return product;
        }

        public async Task DeleteProductAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            await _productsCollection.DeleteOneAsync(filter);
        }

        public async Task<bool> ProductExistsAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var product = await _productsCollection.Find(filter).FirstOrDefaultAsync();
            return product != null;
        }
    }
}