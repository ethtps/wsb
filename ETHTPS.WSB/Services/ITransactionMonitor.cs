using ETHTPS.WSB.Models;

namespace ETHTPS.WSB.Services
{
    public abstract class TransactionMonitor
    {
        private readonly ILogger<TransactionMonitor> _logger;
        private readonly HttpClient _httpClient;
        private readonly BlockchainNetwork _blockchainNetwork;

        public TransactionMonitor(ILogger<TransactionMonitor> logger, HttpClient httpClient, BlockchainNetwork blockchainNetwork)
        {
            _logger = logger;
            _httpClient = httpClient;
            _blockchainNetwork = blockchainNetwork;
        }
    }
}
