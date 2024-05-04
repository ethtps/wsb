using ETHTPS.WSB.Models;

using Newtonsoft.Json;

namespace ETHTPS.WSB.Services
{
    /// <summary>
    /// Represents a service that fetches data from two different sources and aggregates it into a single L2Proxy object. This object is then returned to the caller, who can use it to interact with the various Layer 2 networks.
    /// </summary>
    /// <param name="_logger?"></param>
    /// <param name="_proxyLogger"></param>
    /// <param name="_httpClient"></param>
    public sealed class L2Sweeper
    {
        private readonly ILogger<L2Sweeper>? _logger;
        private readonly ILogger<L2Proxy>? _proxyLogger;
        private readonly HttpClient _httpClient;
        private const string _CHAINZ_URL = "https://chainid.network/chains.json";
        private const string _LLAMA_CHAINZ_URL = "https://api.llama.fi/chains";

        /// <summary>
        /// Minimal constructor for L2Sweeper that requires only the HttpClient.
        /// </summary>
        /// <param name="httpClient">HttpClient used to fetch data from URLs.</param>
        public L2Sweeper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Full constructor for L2Sweeper that also includes logging capabilities.
        /// </summary>
        /// <param name="logger">Logger for L2Sweeper class.</param>
        /// <param name="proxyLogger">Logger for L2Proxy class.</param>
        /// <param name="httpClient">HttpClient used to fetch data from URLs.</param>
        public L2Sweeper(ILogger<L2Sweeper>? logger, ILogger<L2Proxy>? proxyLogger, HttpClient httpClient)
            : this(httpClient) // This calls the minimal constructor first
        {
            _logger = logger;
            _proxyLogger = proxyLogger;
        }

        /// <summary>
        /// Creates a proxy object that can be used to interact with the various Layer 2 networks.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BlockchainNetwork>> SweepAsync()
        {
            List<BlockchainNetwork>? networks = new();
            // See if there's a json file in the project that can be used to populate the networks list - response_1714767793428.json
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "response_1714767793428.json")))
            {
                string json = File.ReadAllText("response_1714767793428.json");
                if (!string.IsNullOrEmpty(json))
                {
                    networks = JsonConvert.DeserializeObject<List<BlockchainNetwork>>(json);
                }
                else
                {
                    _logger?.LogWarning("The JSON file is empty or invalid. Fetching data from the network instead.");
                    return (L2Proxy)Enumerable.Empty<BlockchainNetwork>();
                }
            }
            try
            {
                // Fetch data from the first URL
                var response = await _httpClient.GetAsync(_CHAINZ_URL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var chainzNetworks = JsonConvert.DeserializeObject<List<BlockchainNetwork>>(responseBody);
                if (chainzNetworks != null)
                {
                    networks?.AddRange(chainzNetworks);
                }

                // Fetch data from the second URL 
                response = await _httpClient.GetAsync(_LLAMA_CHAINZ_URL);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                var llamaNetworks = JsonConvert.DeserializeObject<List<BlockchainNetwork>>(responseBody);
                if (llamaNetworks != null)
                {
                    networks?.AddRange(llamaNetworks);
                }
            }
            catch (HttpRequestException e)
            {
                _logger?.LogError($"An error occurred while fetching network data: {e.Message}");
            }
            catch (Exception e)
            {
                _logger?.LogError($"An unexpected error occurred: {e.Message}");
            }

            // Return the populated L2Proxy with the gathered networks
            return networks ?? Enumerable.Empty<BlockchainNetwork>();
        }
    }
}
