using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ManagedEnvironments;


internal class VnetConfigurationModel
{
    [JsonPropertyName("dockerBridgeCidr")]
    public string? DockerBridgeCidr { get; set; }

    [JsonPropertyName("infrastructureSubnetId")]
    public string? InfrastructureSubnetId { get; set; }

    [JsonPropertyName("internal")]
    public bool? Internal { get; set; }

    [JsonPropertyName("platformReservedCidr")]
    public string? PlatformReservedCidr { get; set; }

    [JsonPropertyName("platformReservedDnsIP")]
    public string? PlatformReservedDnsIP { get; set; }

    [JsonPropertyName("runtimeSubnetId")]
    public string? RuntimeSubnetId { get; set; }
}
