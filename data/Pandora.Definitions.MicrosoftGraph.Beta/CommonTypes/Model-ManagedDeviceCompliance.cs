// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedDeviceComplianceModel
{
    [JsonPropertyName("complianceStatus")]
    public string? ComplianceStatus { get; set; }

    [JsonPropertyName("deviceType")]
    public string? DeviceType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inGracePeriodUntilDateTime")]
    public DateTime? InGracePeriodUntilDateTime { get; set; }

    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osDescription")]
    public string? OsDescription { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("ownerType")]
    public string? OwnerType { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
