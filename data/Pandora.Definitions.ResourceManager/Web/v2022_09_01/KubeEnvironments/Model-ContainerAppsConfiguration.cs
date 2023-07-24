using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.KubeEnvironments;


internal class ContainerAppsConfigurationModel
{
    [JsonPropertyName("appSubnetResourceId")]
    public string? AppSubnetResourceId { get; set; }

    [JsonPropertyName("controlPlaneSubnetResourceId")]
    public string? ControlPlaneSubnetResourceId { get; set; }

    [JsonPropertyName("daprAIInstrumentationKey")]
    public string? DaprAIInstrumentationKey { get; set; }

    [JsonPropertyName("dockerBridgeCidr")]
    public string? DockerBridgeCidr { get; set; }

    [JsonPropertyName("platformReservedCidr")]
    public string? PlatformReservedCidr { get; set; }

    [JsonPropertyName("platformReservedDnsIP")]
    public string? PlatformReservedDnsIP { get; set; }
}
