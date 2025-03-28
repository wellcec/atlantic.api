using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using Serilog;
using System.Linq;

using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models;
using Atlantic.Api.Models.Enums;
using Atlantic.Api.Models.WarnMe;
using Atlantic.Api.Services.Interfaces;

namespace Atlantic.Api.Facades
{
    public class WarnMeFacade : IWarnMeFacade
    {
        private readonly IWarnMeService _warnMeService;
        private readonly IRedisService _redisService;
        private readonly ILogger _logger;
        private readonly Dictionary<LogisticsType, Func<WarnMeRecord, Task<bool>>> _logisticTypeFunc = new Dictionary<LogisticsType, Func<WarnMeRecord, Task<bool>>>();


        public WarnMeFacade(IWarnMeService warnMeService, IRedisService redisService, ILogger logger)
        {
            _warnMeService = warnMeService;
            _redisService = redisService;

            _logisticTypeFunc.Add(LogisticsType.ExpressShippingOption, async (request) => await _warnMeService.ExpressShippingOptionAsync(request));
            _logger = logger;
        }

        public async Task CreateWarnMeRecordAsync(WarnMeRecord warnMeRecord)
        {
            _logger.Information("First log in api");

            var t = Task.Run(() =>
            {
                return true;
            });

            t.Wait();
        }
    }
}
