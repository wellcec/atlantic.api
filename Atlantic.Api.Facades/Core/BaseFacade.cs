using AutoMapper;
using Serilog;
using Atlantic.Api.Models.UI;
using Atlantic.Api.Facades.Validators;

namespace Atlantic.Api.Facades.Core
{
    public abstract class BaseFacade
    {
        protected readonly CommonDependenciesFacade CommonDependenciesFacade;
        internal readonly ILogger Logger;
        internal readonly IMapper Mapper;
        internal readonly ApiSettings ApiSettings;
        internal readonly IValidatorHelper ValidatorHelper;

        protected BaseFacade(CommonDependenciesFacade commonDependenciesFacade)
        {
            Logger = commonDependenciesFacade.Logger;
            Mapper = commonDependenciesFacade.Mapper;
            ApiSettings = commonDependenciesFacade.ApiSettings;
            ValidatorHelper = commonDependenciesFacade.ValidatorHelper;
        }
    }
}
