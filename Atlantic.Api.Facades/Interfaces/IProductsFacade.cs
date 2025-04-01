using System.Threading.Tasks;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Requests;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface IProductsFacade
    {
        ListProductsResponse GetAll(FilterProductsDTO filter);
        Task<BaseResponse> GetByIdAsync(string id);
        Task<BaseResponse> InsertProductAsync(ProductDTO product);
        Task<BaseResponse> DeleteProductAsync(string id);
    }
}
