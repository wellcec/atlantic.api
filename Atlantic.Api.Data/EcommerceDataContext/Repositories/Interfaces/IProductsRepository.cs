using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Requests;
using Atlantic.Api.Models.Responses;
using MongoDB.Bson;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        ListProductsResponse GetAll(FilterProductsDTO filter);
        Task<List<ProductDTO>> GetByIdAsync(ObjectId id);
        Task<Product> InsertProductAsync(Product product);
        Task<long> UpdateAsync(ObjectId id, Product product);
        Task<long> DeleteAsync(ObjectId id);
        Task<List<Product>> GeyByCategoryIdAsync(ObjectId categoryId);
    }
}
