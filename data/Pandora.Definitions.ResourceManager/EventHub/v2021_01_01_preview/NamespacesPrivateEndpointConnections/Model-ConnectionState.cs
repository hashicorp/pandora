using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{

    internal class ConnectionState
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        public PrivateLinkConnectionStatus? Status { get; set; }
    }
}
