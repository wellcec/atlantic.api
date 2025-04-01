using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models.Extensions;
using Atlantic.Api.Models.Context.Products;
using Microsoft.AspNetCore.Http;

namespace Atlantic.Api.Controllers
{
    /// <summary>
    /// Images Controller Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesFacade _imagesFacade;

        /// <summary>
        /// ImagesController
        /// </summary>
        /// <param name="imagesFacade"> imagesFacade</param>
        public ImagesController(IImagesFacade imagesFacade)
        {
            _imagesFacade = imagesFacade;
        }

        /// <summary>
        /// Add new image
        /// </summary>
        /// <param name="data">File</param>
        [HttpPost("save")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _imagesFacade.SaveTemporaryImageAsync(file);
            return result.ToActionResult();
        }

        /// <summary>
        /// Save images definitive
        /// </summary>
        [HttpPost("save/definitive")]
        public async Task<IActionResult> SaveDefinitiveAsync()
        {
            var result = await _imagesFacade.ProcessImageAsync();
            return result.ToActionResult();
        }

        /// <summary>
        /// Get all files in bucket
        /// </summary>
        [HttpGet("all/bucket")]
        public async Task<IActionResult> GetAllFilesAsync()
        {
            var result = await _imagesFacade.GetAllFilesAsync();
            return result.ToActionResult();
        }

        /// <summary>
        /// Get all files in repository
        /// </summary>
        [HttpGet("all/temporary")]
        public IActionResult GetTemporaryImagesAsync()
        {
            var result = _imagesFacade.GetTemporaryImagesAsync();
            return Ok(result);
        }
    }
}
