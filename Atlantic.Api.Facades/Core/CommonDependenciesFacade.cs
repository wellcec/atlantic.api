using AutoMapper;
using Serilog;
using Atlantic.Api.Models.UI;

namespace Atlantic.Api.Facades.Core
{
    public class CommonDependenciesFacade
    {
        public ILogger Logger { get; private set; }

        public IMapper Mapper { get; private set; }

        public ApiSettings ApiSettings { get; private set; }


        public CommonDependenciesFacade(ILogger logger, IMapper mapper, ApiSettings apiSettings)
        {
            Logger = logger;
            Mapper = mapper;
            ApiSettings = apiSettings;
        }
    }
}
