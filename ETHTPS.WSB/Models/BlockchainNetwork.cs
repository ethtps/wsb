namespace ETHTPS.WSB.Models
{
    public sealed class BlockchainNetwork
    {
        public required string Name { get; set; }
        public required string Chain { get; set; }
        public required string Icon { get; set; }
        public required List<string> Rpc { get; set; }
        public required List<Feature> Features { get; set; }
        public required List<object> Faucets { get; set; } // Assuming empty array.
        public required NativeCurrency NativeCurrency { get; set; }
        public required string InfoURL { get; set; }
        public required string ShortName { get; set; }
        public required Int128? ChainId { get; set; }
        public required Int128 NetworkId { get; set; }
        public required Int128 Slip44 { get; set; }
        public required Ens Ens { get; set; }
        public required List<Explorer> Explorers { get; set; }
        public required string GeckoId { get; set; }
        public required double Tvl { get; set; }
        public required string TokenSymbol { get; set; }
        public required Int128? CmcId { get; set; } // Nullable to handle null values.
    }
    public sealed class Feature
    {
        public required string Name { get; set; }
    }

    public sealed class NativeCurrency
    {
        public required string Name { get; set; }
        public required string Symbol { get; set; }
        public required Int128 Decimals { get; set; }
    }

    public sealed class Ens
    {
        public required string Registry { get; set; }
    }

    public sealed class Explorer
    {
        public required string Name { get; set; }
        public required string Url { get; set; }
        public required string Icon { get; set; }
        public required string Standard { get; set; }
    }

}
