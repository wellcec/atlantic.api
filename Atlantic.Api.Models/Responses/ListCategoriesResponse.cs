using System.Collections.Generic;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;

namespace Atlantic.Api.Models.Responses
{
    public class ListCategoriesResponse : BaseListResponse
    {
        public List<CategoryDTO> Data { get; set; }
    }
}
