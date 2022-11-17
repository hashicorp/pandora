using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedCluster;


internal class LoadBalancingRuleModel
{
    [JsonPropertyName("backendPort")]
    [Required]
    public int BackendPort { get; set; }

    [JsonPropertyName("frontendPort")]
    [Required]
    public int FrontendPort { get; set; }

    [JsonPropertyName("loadDistribution")]
    public string? LoadDistribution { get; set; }

    [JsonPropertyName("probePort")]
    public int? ProbePort { get; set; }

    [JsonPropertyName("probeProtocol")]
    [Required]
    public ProbeProtocolConstant ProbeProtocol { get; set; }

    [JsonPropertyName("probeRequestPath")]
    public string? ProbeRequestPath { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public ProtocolConstant Protocol { get; set; }
}
