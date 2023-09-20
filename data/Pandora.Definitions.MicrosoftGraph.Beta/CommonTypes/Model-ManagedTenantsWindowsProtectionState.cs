// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsWindowsProtectionStateModel
{
    [JsonPropertyName("antiMalwareVersion")]
    public string? AntiMalwareVersion { get; set; }

    [JsonPropertyName("attentionRequired")]
    public bool? AttentionRequired { get; set; }

    [JsonPropertyName("deviceDeleted")]
    public bool? DeviceDeleted { get; set; }

    [JsonPropertyName("devicePropertyRefreshDateTime")]
    public DateTime? DevicePropertyRefreshDateTime { get; set; }

    [JsonPropertyName("engineVersion")]
    public string? EngineVersion { get; set; }

    [JsonPropertyName("fullScanOverdue")]
    public bool? FullScanOverdue { get; set; }

    [JsonPropertyName("fullScanRequired")]
    public bool? FullScanRequired { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastFullScanDateTime")]
    public DateTime? LastFullScanDateTime { get; set; }

    [JsonPropertyName("lastFullScanSignatureVersion")]
    public string? LastFullScanSignatureVersion { get; set; }

    [JsonPropertyName("lastQuickScanDateTime")]
    public DateTime? LastQuickScanDateTime { get; set; }

    [JsonPropertyName("lastQuickScanSignatureVersion")]
    public string? LastQuickScanSignatureVersion { get; set; }

    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("lastReportedDateTime")]
    public DateTime? LastReportedDateTime { get; set; }

    [JsonPropertyName("malwareProtectionEnabled")]
    public bool? MalwareProtectionEnabled { get; set; }

    [JsonPropertyName("managedDeviceHealthState")]
    public string? ManagedDeviceHealthState { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("networkInspectionSystemEnabled")]
    public bool? NetworkInspectionSystemEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("quickScanOverdue")]
    public bool? QuickScanOverdue { get; set; }

    [JsonPropertyName("realTimeProtectionEnabled")]
    public bool? RealTimeProtectionEnabled { get; set; }

    [JsonPropertyName("rebootRequired")]
    public bool? RebootRequired { get; set; }

    [JsonPropertyName("signatureUpdateOverdue")]
    public bool? SignatureUpdateOverdue { get; set; }

    [JsonPropertyName("signatureVersion")]
    public string? SignatureVersion { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
