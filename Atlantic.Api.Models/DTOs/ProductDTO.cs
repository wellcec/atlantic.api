using System.Collections.Generic;
using Atlantic.Api.Models.Context.Products;

namespace Atlantic.Api.Models.DTOs
{
    public class ProductDTO : Product
    {
        public new string id { get; set; }
        public new List<CategoryDTO> categories { get; set; } = new List<CategoryDTO>();
        public new List<VariationDTO> variations { get; set; } = new List<VariationDTO>();
        public new List<ImageDTO> images { get; set; } = new List<ImageDTO>();
    }
}
