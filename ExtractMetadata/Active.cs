using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExtractData
{
    public class Active
    {
        [JsonPropertyName("signature")]
        public string? Signature { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("tokenMint")]
        public string? TokenMint { get; set; }

        [JsonPropertyName("collection")]
        public string? Collection { get; set; }

        [JsonPropertyName("collectionSymbol")]
        public string? CollectionSymbol { get; set; }

        [JsonPropertyName("slot")]
        public int? Slot { get; set; }

        [JsonPropertyName("blockTime")]
        public long BlockTime { get; set; }

        [JsonPropertyName("buyer")]
        public object? Buyer { get; set; }

        [JsonPropertyName("buyerReferral")]
        public string? BuyerReferral { get; set; }

        [JsonPropertyName("seller")]
        public string? Seller { get; set; }

        [JsonPropertyName("sellerReferral")]
        public string? SellerReferral { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }
    }
}
