using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateEndpointConnections
{
    internal class PrivateEndpoint
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
