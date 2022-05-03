using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.NamespacesPrivateEndpointConnections;


internal class ConnectionStateModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("status")]
    public PrivateLinkConnectionStatusConstant? Status { get; set; }
}
