using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models.Extensions;
using Atlantic.Api.Models.Context.Products;
using System.Xml.Linq;
using Atlantic.Api.Models.DTOs;

namespace Atlantic.Api.Controllers
{
    /// <summary>
    /// Products Controller Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesFacade _categoriesFacade;

        /// <summary>
        /// CategoriesController
        /// </summary>
        /// <param name="categoriesFacade"> categoriesFacade</param>
        public CategoriesController(ICategoriesFacade categoriesFacade)
        {
            _categoriesFacade = categoriesFacade;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="term">term</param>
        [HttpGet()]
        public IActionResult GetAll([FromQuery] int page, int pageSize, string term)
        {
            var result = _categoriesFacade.GetAll(page, pageSize, term);
            return Ok(result);
        }

        /// <summary>
        /// Add new Category
        /// </summary>
        /// <param name="data">Category</param>
        [HttpPost("create")]
        public async Task<IActionResult> InsertCategoryAsync([FromBody] CategoryDTO data)
        {
            var result = await _categoriesFacade.InsertCategoryAsync(data);

            return result.ToActionResult();
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">Id Category</param>
        /// <param name="data">Category</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> InsertCategoryAsync([FromRoute] string id, [FromBody] CategoryDTO data)
        {
            var result = await _categoriesFacade.UpdateCategoryAsync(id, data);

            return result.ToActionResult();
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id">Id Category</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] string id)
        {
            var result = await _categoriesFacade.DeleteCategoryAsync(id);

            return result.ToActionResult();
        }
    }
}
