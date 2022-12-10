using System.Text.Json.Serialization;

namespace ExtractData
{
    public class Metadata
    {
        [JsonPropertyName("mintAddress")] 
        public string? MintAddress { get; set; }
        [JsonPropertyName("owner")] 
        public string? Owner { get; set; }
        [JsonPropertyName("supply")] 
        public int Supply { get; set; }
        [JsonPropertyName("delegate")] 
        public string? Delegate { get; set; }
        [JsonPropertyName("collection")] 
        public string? Collection { get; set; }
        [JsonPropertyName("name")] 
        public string? Name { get; set; }
        [JsonPropertyName("updateAuthority")] 
        public string? UpdateAuthority { get; set; }
        [JsonPropertyName("primarySaleHappened")] 
        public bool PrimarySaleHappened { get; set; }
        [JsonPropertyName("sellerFeeBasisPoints")] 
        public int SellerFeeBasisPoints { get; set; }
        [JsonPropertyName("image")] 
        public string? Image { get; set; }
        [JsonPropertyName("attributes")] 
        public Attribute[]? Attributes { get; set; }
        [JsonPropertyName("properties")] 
        public Properties? Properties { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("files")] 
        public File[]? Files { get; set; }
        [JsonPropertyName("category")] 
        public object? Category { get; set; }
    }

    public class File
    {
        [JsonPropertyName("uri")] 
        public string? Uri { get; set; }
        [JsonPropertyName("type")] 
        public string? Type { get; set; }
    }

    public class Attribute
    {
        [JsonPropertyName("trait_type")] 
        public string? Trait_type { get; set; }
        [JsonPropertyName("value")] 
        public string? Value { get; set; }
    }

}
