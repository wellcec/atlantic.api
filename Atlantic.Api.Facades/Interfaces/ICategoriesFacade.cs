using System.Threading.Tasks;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface ICategoriesFacade
    {
        ListCategoriesResponse GetAll(int page, int pageSize, string term);
        Task<BaseResponse> InsertCategoryAsync(Category category);
    }
}
