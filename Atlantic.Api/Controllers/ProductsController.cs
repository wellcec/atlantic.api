using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models.WarnMe;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using System.Linq;
using MongoDB.Bson;

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

        /// <summary>
        /// ProductsController
        /// </summary>
        /// <param name="repository"> repository</param>
        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Add new Warn Me
        /// </summary>
        /// <param name="warnMeRecord">Warn Me record</param>
        [HttpGet()]
        public async Task <IActionResult> GetAllProductsAsync()
        {
            var list = _repository.GetProducts();

            return Ok(
                list.Select(x => new
                {
                    id = x._id.ToString(),
                    x.name
                })
            );
        }
    }
}
