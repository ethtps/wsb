using ETHTPS.WSB.Models;
using ETHTPS.WSB.Services;

using Microsoft.AspNetCore.Mvc;

namespace ETHTPS.WSB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweepController : ControllerBase
    {
        private readonly L2Sweeper _sweeper;

        public SweepController(L2Sweeper sweeper)
        {
            _sweeper = sweeper;
        }

        [HttpGet]
        public async Task<IEnumerable<BlockchainNetwork>> Get()
        {
            return await _sweeper.SweepAsync();
        }
    }
}
