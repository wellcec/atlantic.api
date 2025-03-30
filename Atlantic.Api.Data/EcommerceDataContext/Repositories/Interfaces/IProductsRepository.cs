using Atlantic.Api.Models.Context.Products;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Task<Product> InsertProductAsync(Product product);
    }
}
