using System.Threading.Tasks;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface IVariationsFacade
    {
        ListVariationsResponse GetAll(int page, int pageSize, string term);
        Task<BaseResponse> InsertVariationAsync(Variation variation);
        Task<BaseResponse> DeleteAsync(string id);
    }
}
