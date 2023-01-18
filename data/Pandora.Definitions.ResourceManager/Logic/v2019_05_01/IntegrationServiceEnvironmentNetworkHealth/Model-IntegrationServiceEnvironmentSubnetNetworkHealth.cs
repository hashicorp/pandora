using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentNetworkHealth;


internal class IntegrationServiceEnvironmentSubnetNetworkHealthModel
{
    [JsonPropertyName("networkDependencyHealthState")]
    [Required]
    public IntegrationServiceEnvironmentNetworkEndPointAccessibilityStateConstant NetworkDependencyHealthState { get; set; }

    [JsonPropertyName("outboundNetworkDependencies")]
    public List<IntegrationServiceEnvironmentNetworkDependencyModel>? OutboundNetworkDependencies { get; set; }

    [JsonPropertyName("outboundNetworkHealth")]
    public IntegrationServiceEnvironmentNetworkDependencyHealthModel? OutboundNetworkHealth { get; set; }
}
