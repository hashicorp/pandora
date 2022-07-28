using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class SingleQueryResultModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinationPorts")]
    public List<string>? DestinationPorts { get; set; }

    [JsonPropertyName("direction")]
    public FirewallPolicyIDPSSignatureDirectionConstant? Direction { get; set; }

    [JsonPropertyName("group")]
    public string? Group { get; set; }

    [JsonPropertyName("inheritedFromParentPolicy")]
    public bool? InheritedFromParentPolicy { get; set; }

    [JsonPropertyName("lastUpdated")]
    public string? LastUpdated { get; set; }

    [JsonPropertyName("mode")]
    public FirewallPolicyIDPSSignatureModeConstant? Mode { get; set; }

    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    [JsonPropertyName("severity")]
    public FirewallPolicyIDPSSignatureSeverityConstant? Severity { get; set; }

    [JsonPropertyName("signatureId")]
    public int? SignatureId { get; set; }

    [JsonPropertyName("sourcePorts")]
    public List<string>? SourcePorts { get; set; }
}
