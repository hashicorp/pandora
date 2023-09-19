// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCDomainJoinConfigurationModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesConnectionId")]
    public string? OnPremisesConnectionId { get; set; }

    [JsonPropertyName("regionGroup")]
    public CloudPCDomainJoinConfigurationRegionGroupConstant? RegionGroup { get; set; }

    [JsonPropertyName("regionName")]
    public string? RegionName { get; set; }

    [JsonPropertyName("type")]
    public CloudPCDomainJoinConfigurationTypeConstant? Type { get; set; }
}
