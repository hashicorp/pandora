// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessCrossTenantSummaryModel
{
    [JsonPropertyName("authTransactionCount")]
    public int? AuthTransactionCount { get; set; }

    [JsonPropertyName("deviceCount")]
    public int? DeviceCount { get; set; }

    [JsonPropertyName("newTenantCount")]
    public int? NewTenantCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantCount")]
    public int? TenantCount { get; set; }

    [JsonPropertyName("userCount")]
    public int? UserCount { get; set; }
}
