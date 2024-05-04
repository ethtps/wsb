using System.Collections;

using ETHTPS.WSB.Models;

namespace ETHTPS.WSB.Services
{
    /// <summary>
    /// Represents a proxy for interacting with L2 networks.
    /// </summary>
    public sealed class L2Proxy : IEnumerable<BlockchainNetwork>
    {
        public IList<BlockchainNetwork> Networks { get; private set; }
        private readonly ILogger<L2Proxy>? _logger;
        private readonly HttpClient _httpClient;

        public BlockchainNetwork this[int index]
        {
            get => Networks[index];
            set => Networks[index] = value;
        }

        public int Count => Networks.Count;

        public bool IsReadOnly => Networks.IsReadOnly;

        public L2Proxy(IEnumerable<BlockchainNetwork> networks, HttpClient httpClient)
        {
            Networks = networks.ToList();
            _httpClient = httpClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="L2Proxy"/> class.
        /// </summary>
        /// <param name="networks"></param>
        /// <param name="logger"></param>
        /// <param name="httpClient"></param>
        public L2Proxy(IEnumerable<BlockchainNetwork> networks, ILogger<L2Proxy>? logger, HttpClient httpClient)
        {
            Networks = networks.ToList();
            _logger = logger;
            _httpClient = httpClient;
        }

        public IEnumerator<BlockchainNetwork> GetEnumerator()
        {
            return Networks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Networks).GetEnumerator();
        }
    }
}
