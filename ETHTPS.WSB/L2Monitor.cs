using ETHTPS.WSB.Models;
using ETHTPS.WSB.Services;

public class L2Monitor : TransactionMonitor
{
    public event EventHandler<L2Proxy> L2Discovered;
    public event EventHandler<L2Proxy> L2Lost;
    protected L2Monitor(ILogger<TransactionMonitor> logger, HttpClient httpClient, BlockchainNetwork blockchainNetwork) : base(logger, httpClient, blockchainNetwork)
    {

    }

    public Task MonitorAsync()
    {
        return Task.CompletedTask;
    }
}
