using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models.WarnMe;

namespace Atlantic.Api.Controllers
{
    /// <summary>
    /// Events Controller Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class WarnMeController : ControllerBase
    {
        private readonly IWarnMeFacade _warnMeFacade;

        /// <summary>
        /// Payment Construct
        /// </summary>
        /// <param name="warnMeFacade"> WarnMe Facade</param>
        public WarnMeController(IWarnMeFacade warnMeFacade)
        {
            _warnMeFacade = warnMeFacade;
        }

        /// <summary>
        /// Add new Warn Me
        /// </summary>
        /// <param name="warnMeRecord">Warn Me record</param>
        [HttpPost("create")]
        public async Task <IActionResult> CreateWarnMeRecordAsync(WarnMeRecord warnMeRecord)
        {
            await _warnMeFacade.CreateWarnMeRecordAsync(warnMeRecord);
         
            return Ok();
        }
    }
}
