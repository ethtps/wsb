using ETHTPS.WSB.Models;

namespace ETHTPS.WSB.Services
{
    public interface IWeb3Proxy
    {
        Task<BlockchainNetwork> GetLatestBlockDataAsync();
    }
}
