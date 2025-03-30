using System.Threading.Tasks;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface IProductsFacade
    {
        Task<BaseResponse> InsertProductAsync(Product product);
    }
}
