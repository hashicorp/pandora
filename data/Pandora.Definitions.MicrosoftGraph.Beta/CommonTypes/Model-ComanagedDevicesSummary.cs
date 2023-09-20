// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ComanagedDevicesSummaryModel
{
    [JsonPropertyName("compliancePolicyCount")]
    public int? CompliancePolicyCount { get; set; }

    [JsonPropertyName("configurationSettingsCount")]
    public int? ConfigurationSettingsCount { get; set; }

    [JsonPropertyName("endpointProtectionCount")]
    public int? EndpointProtectionCount { get; set; }

    [JsonPropertyName("inventoryCount")]
    public int? InventoryCount { get; set; }

    [JsonPropertyName("modernAppsCount")]
    public int? ModernAppsCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeAppsCount")]
    public int? OfficeAppsCount { get; set; }

    [JsonPropertyName("resourceAccessCount")]
    public int? ResourceAccessCount { get; set; }

    [JsonPropertyName("totalComanagedCount")]
    public int? TotalComanagedCount { get; set; }

    [JsonPropertyName("windowsUpdateForBusinessCount")]
    public int? WindowsUpdateForBusinessCount { get; set; }
}
