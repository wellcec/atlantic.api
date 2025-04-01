using System.Collections.Generic;
using Atlantic.Api.Models.DTOs;

namespace Atlantic.Api.Models.Responses
{
    public class ListProductsResponse : BaseListResponse
    {
        public List<ProductDTO> Data { get; set; }
    }
}
