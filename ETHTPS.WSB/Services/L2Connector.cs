namespace ETHTPS.WSB.Services
{
    public sealed class L2Connector : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<L2Connector>? _logger;
        private readonly string _rpcUrl;

        public L2Connector(string rpcUrl, HttpClient httpClient, ILogger<L2Connector>? logger = null)
        {
            _rpcUrl = rpcUrl;
            _httpClient = httpClient;
            _logger = logger;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
