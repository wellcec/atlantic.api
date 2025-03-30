using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Responses;
using MongoDB.Bson;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        ListCategoriesResponse GetAll(int page, int pageSize, string? term);
        Task<CategoryDTO> InsertAsync(Category item);
        Task<long> DeleteAsync(ObjectId id);
        Task<CategoryDTO> GetById(ObjectId id);
        Task<long> UpdateAsync(ObjectId id, Category category);
    }
}
