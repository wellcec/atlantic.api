using System.Threading.Tasks;
using AutoMapper;
using Atlantic.Api.Models.WarnMe;
using Atlantic.Api.Services.Interfaces;

namespace Atlantic.Api.Services
{
    public class WarnMeService : IWarnMeService
    {
        private readonly IMapper _mapper;

        public WarnMeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> ExpressShippingOptionAsync(WarnMeRecord warnMeRecord)
        {
            return false;
        }
    }
}
