using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.UI;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<Product> Products;

        public ProductsRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            Products = database.GetCollection<Product>("Products");
        }

        public List<Product> GetProducts() 
        {
            return Products.Find(_ => true).ToList();
        }

        public async Task<Product> InsertProductAsync(Product product)
        {
            await Products.InsertOneAsync(product);
            return product;
        }

        public async Task<long> UpdateAsync(ObjectId id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq("id", id);
            var result = await Products.ReplaceOneAsync(filter, product);
            return result.ModifiedCount;
        }

        public async Task<List<Product>> GeyByCategoryIdAsync(ObjectId categoryId)
        {
            var filter = Builders<Product>.Filter.ElemMatch<Category>("categories", Builders<Category>.Filter.Eq("id", categoryId));
            var products = await Products.FindAsync(filter);
            return products.ToList();
        }
    }
}