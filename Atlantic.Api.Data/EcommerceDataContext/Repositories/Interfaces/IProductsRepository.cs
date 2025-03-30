using Atlantic.Api.Models.Context.Products;
using MongoDB.Bson;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Task<Product> InsertProductAsync(Product product);
        Task<long> UpdateAsync(ObjectId id, Product product);
        Task<List<Product>> GeyByCategoryIdAsync(ObjectId categoryId);
    }
}
