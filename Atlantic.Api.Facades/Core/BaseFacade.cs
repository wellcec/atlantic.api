using AutoMapper;
using Serilog;
using Atlantic.Api.Models.UI;

namespace Atlantic.Api.Facades.Core
{
    public abstract class BaseFacade
    {
        protected readonly CommonDependenciesFacade CommonDependenciesFacade;
        internal readonly ILogger Logger;
        internal readonly IMapper Mapper;
        internal readonly ApiSettings ApiSettings;

        protected BaseFacade(CommonDependenciesFacade commonDependenciesFacade)
        {
            Logger = commonDependenciesFacade.Logger;
            Mapper = commonDependenciesFacade.Mapper;
            ApiSettings = commonDependenciesFacade.ApiSettings; ;
        }
    }
}
