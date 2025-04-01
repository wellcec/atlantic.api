using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using MongoDB.Bson;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces
{
    public interface IImagesRepository
    {
        List<ImageDTO> GetAll();
        Task<ImageDTO> GetByIdAsync(ObjectId id);
        Task<ImageDTO> InsertAsync(Image item);
        Task<long> DeleteAsync(ObjectId id);
        Task<long> DeleteAllAsync();
    }
}
