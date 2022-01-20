using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.OutboundNetworkDependenciesEndpoints;


internal class OutboundEnvironmentEndpointModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("endpoints")]
    public List<EndpointDependencyModel>? Endpoints { get; set; }
}
