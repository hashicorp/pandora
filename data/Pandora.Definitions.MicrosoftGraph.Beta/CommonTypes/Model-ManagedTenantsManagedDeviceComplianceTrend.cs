// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagedDeviceComplianceTrendModel
{
    [JsonPropertyName("compliantDeviceCount")]
    public int? CompliantDeviceCount { get; set; }

    [JsonPropertyName("configManagerDeviceCount")]
    public int? ConfigManagerDeviceCount { get; set; }

    [JsonPropertyName("countDateTime")]
    public string? CountDateTime { get; set; }

    [JsonPropertyName("errorDeviceCount")]
    public int? ErrorDeviceCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inGracePeriodDeviceCount")]
    public int? InGracePeriodDeviceCount { get; set; }

    [JsonPropertyName("noncompliantDeviceCount")]
    public int? NoncompliantDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("unknownDeviceCount")]
    public int? UnknownDeviceCount { get; set; }
}
