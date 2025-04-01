using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.Responses;
using MongoDB.Bson;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces
{
    public interface IVariationsRepository
    {
        ListVariationsResponse GetAll(int page, int pageSize, string? term);
        Task<Variation> InsertAsync(Variation item);
        Task<long> DeleteAsync(ObjectId id);
    }
}
