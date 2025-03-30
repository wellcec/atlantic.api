using Atlantic.Api.Models.Context.Products;

namespace Atlantic.Api.Models.DTOs
{
    public class CategoryDTO : Category
    {
        public new string id { get; set; }
    }
}
