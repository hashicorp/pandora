using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.OnlineEndpoint;


internal class OnlineEndpointModel
{
    [JsonPropertyName("authMode")]
    [Required]
    public EndpointAuthModeConstant AuthMode { get; set; }

    [JsonPropertyName("compute")]
    public string? Compute { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("keys")]
    public EndpointAuthKeysModel? Keys { get; set; }

    [JsonPropertyName("mirrorTraffic")]
    public Dictionary<string, int>? MirrorTraffic { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("provisioningState")]
    public EndpointProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("scoringUri")]
    public string? ScoringUri { get; set; }

    [JsonPropertyName("swaggerUri")]
    public string? SwaggerUri { get; set; }

    [JsonPropertyName("traffic")]
    public Dictionary<string, int>? Traffic { get; set; }
}
