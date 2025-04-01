using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models.Extensions;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Requests;

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
        private readonly IProductsFacade _productsFacade;

        /// <summary>
        /// ProductsController
        /// </summary>
        /// <param name="productsFacade"> productsFacade</param>
        public ProductsController(IProductsFacade productsFacade)
        {
            _productsFacade = productsFacade;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="asc">sort</param>
        /// <param name="term">term</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="nameSubcategory">nameSubcategory</param>
        /// <param name="tags">tags</param>
        /// <param name="minValue">minValue</param>
        /// <param name="maxValue">maxValue</param>
        [HttpGet()]
        public IActionResult GetAll(
            [FromQuery] int page,
            int pageSize,
            bool asc,
            string term,
            string categoryId,
            string nameSubcategory,
            string tags,
            double? minValue,
            double? maxValue
            )
        {
            var filter = new FilterProductsDTO()
            {
                page = page,
                pageSize = pageSize,
                asc = asc,
                term = term,
                categoryId = categoryId,
                nameSubcategory = nameSubcategory,
                tags = tags.Split(";"),
                minValue = minValue,
                maxValue = maxValue
            };

            var list = _productsFacade.GetAll(filter);

            return Ok(list);
        }

        /// <summary>
        /// Get product
        /// </summary>
        /// <param name="id">page</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] string id)
        {
            var result = await _productsFacade.GetByIdAsync(id);

            return result.ToActionResult();
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">product</param>
        [HttpPost("create")]
        public async Task<IActionResult> InsertProductAsync([FromBody] ProductDTO product)
        {
            var result = await _productsFacade.InsertProductAsync(product);

            return result.ToActionResult();
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="id">id product</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] string id)
        {
            var result = await _productsFacade.DeleteProductAsync(id);

            return result.ToActionResult();
        }
    }
}
