using System.Threading.Tasks;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface ICategoriesFacade
    {
        ListCategoriesResponse GetAll(int page, int pageSize, string term);
        Task<BaseResponse> InsertCategoryAsync(CategoryDTO category);
        Task<BaseResponse> UpdateCategoryAsync(string id, CategoryDTO category);
        Task<BaseResponse> DeleteCategoryAsync(string id);
    }
}
