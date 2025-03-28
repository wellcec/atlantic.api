using System.Threading.Tasks;

using Atlantic.Api.Models.WarnMe;

namespace Atlantic.Api.Facades.Interfaces
{
    public interface IWarnMeFacade
    {
        Task CreateWarnMeRecordAsync(WarnMeRecord warnMeRecord);
    }
}
