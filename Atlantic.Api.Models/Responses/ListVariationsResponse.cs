using System.Collections.Generic;
using Atlantic.Api.Models.DTOs;

namespace Atlantic.Api.Models.Responses
{
    public class ListVariationsResponse : BaseListResponse
    {
        public List<VariationDTO> Data { get; set; }
    }
}
