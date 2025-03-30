using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atlantic.Api.Facades.Interfaces;
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
    public class VariationsController : ControllerBase
    {
        private readonly IVariationsFacade _variationsFacade;

        /// <summary>
        /// VariationsController
        /// </summary>
        /// <param name="variationsFacade"> variationsFacade</param>
        public VariationsController(IVariationsFacade variationsFacade)
        {
            _variationsFacade = variationsFacade;
        }

        /// <summary>
        /// Add new Variation
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="term">term</param>
        [HttpGet()]
        public IActionResult GetAll([FromQuery] int page, int pageSize, string term)
        {
            var result = _variationsFacade.GetAll(page, pageSize, term);
            return Ok(result);
        }

        /// <summary>
        /// Add new Variation
        /// </summary>
        /// <param name="data">Variation</param>
        [HttpPost("create")]
        public async Task<IActionResult> InsertVariationAsync([FromBody] Variation data)
        {
            var result = await _variationsFacade.InsertVariationAsync(data);
            return result.ToActionResult();
        }

        /// <summary>
        /// Delete Variation
        /// </summary>
        /// <param name="id">Variation</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariationAsync([FromRoute] string id)
        {
            var result = await _variationsFacade.DeleteAsync(id);
            return Ok(result);
        }
    }
}
