using System.Threading.Tasks;

using Atlantic.Api.Models.WarnMe;

namespace Atlantic.Api.Services.Interfaces
{
    public interface IWarnMeService
    {
        /// <summary>
        /// Check and send notice notifications for express delivery
        /// </summary>
        /// <param name="warnMeRecord">Warn Me</param>
        /// <returns>Inventory check result</returns>
        Task<bool> ExpressShippingOptionAsync(WarnMeRecord warnMeRecord);
    }
}
