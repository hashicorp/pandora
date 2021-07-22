using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.KeyValues
{
    internal class KeyValue
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("content_type")]
        public string? ContentType { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("last_modified")]
        public string? LastModified { get; set; }

        [JsonPropertyName("tags")]
        public object? Tags { get; set; }

        [JsonPropertyName("locked")]
        public bool? Locked { get; set; }

        [JsonPropertyName("etag")]
        public string? Etag { get; set; }
    }
}
