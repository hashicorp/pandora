using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders;


internal class StatusResultModel
{
    [JsonPropertyName("attestUri")]
    public string? AttestUri { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("status")]
    public AttestationServiceStatusConstant? Status { get; set; }

    [JsonPropertyName("trustModel")]
    public string? TrustModel { get; set; }
}
