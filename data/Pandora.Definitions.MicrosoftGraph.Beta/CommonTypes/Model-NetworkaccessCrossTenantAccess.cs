// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessCrossTenantAccessModel
{
    [JsonPropertyName("deviceCount")]
    public int? DeviceCount { get; set; }

    [JsonPropertyName("lastAccessDateTime")]
    public DateTime? LastAccessDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceTenantId")]
    public string? ResourceTenantId { get; set; }

    [JsonPropertyName("resourceTenantName")]
    public string? ResourceTenantName { get; set; }

    [JsonPropertyName("resourceTenantPrimaryDomain")]
    public string? ResourceTenantPrimaryDomain { get; set; }

    [JsonPropertyName("usageStatus")]
    public NetworkaccessCrossTenantAccessUsageStatusConstant? UsageStatus { get; set; }

    [JsonPropertyName("userCount")]
    public int? UserCount { get; set; }
}
