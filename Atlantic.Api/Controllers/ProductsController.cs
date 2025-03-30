using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using System.Linq;
using Atlantic.Api.Models.Extensions;
using Atlantic.Api.Models.Context.Products;

namespace Atlantic.Api.Controllers
{
    /// <summary>
    /// Products Controller Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        private readonly IProductsFacade _productsFacade;

        /// <summary>
        /// ProductsController
        /// </summary>
        /// <param name="repository"> repository</param>
        /// <param name="productsFacade"> productsFacade</param>
        public ProductsController(IProductsRepository repository, IProductsFacade productsFacade)
        {
            _repository = repository;
            _productsFacade = productsFacade;
        }

        /// <summary>
        /// Add new Warn Me
        /// </summary>
        /// <param name="warnMeRecord">Warn Me record</param>
        [HttpGet()]
        public async Task <IActionResult> GetAllProductsAsync()
        {
            var list = _repository.GetProducts();

            return Ok(list);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">product</param>
        [HttpPost("create")]
        public async Task<IActionResult> InserProductAsync([FromBody] Product product)
        {
            var result = await _productsFacade.InsertProductAsync(product);

            return result.ToActionResult();
        }
    }
}
