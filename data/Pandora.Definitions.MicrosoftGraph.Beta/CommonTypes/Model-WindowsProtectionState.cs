// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsProtectionStateModel
{
    [JsonPropertyName("antiMalwareVersion")]
    public string? AntiMalwareVersion { get; set; }

    [JsonPropertyName("detectedMalwareState")]
    public List<WindowsDeviceMalwareStateModel>? DetectedMalwareState { get; set; }

    [JsonPropertyName("deviceState")]
    public WindowsDeviceHealthStateConstant? DeviceState { get; set; }

    [JsonPropertyName("engineVersion")]
    public string? EngineVersion { get; set; }

    [JsonPropertyName("fullScanOverdue")]
    public bool? FullScanOverdue { get; set; }

    [JsonPropertyName("fullScanRequired")]
    public bool? FullScanRequired { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isVirtualMachine")]
    public bool? IsVirtualMachine { get; set; }

    [JsonPropertyName("lastFullScanDateTime")]
    public DateTime? LastFullScanDateTime { get; set; }

    [JsonPropertyName("lastFullScanSignatureVersion")]
    public string? LastFullScanSignatureVersion { get; set; }

    [JsonPropertyName("lastQuickScanDateTime")]
    public DateTime? LastQuickScanDateTime { get; set; }

    [JsonPropertyName("lastQuickScanSignatureVersion")]
    public string? LastQuickScanSignatureVersion { get; set; }

    [JsonPropertyName("lastReportedDateTime")]
    public DateTime? LastReportedDateTime { get; set; }

    [JsonPropertyName("malwareProtectionEnabled")]
    public bool? MalwareProtectionEnabled { get; set; }

    [JsonPropertyName("networkInspectionSystemEnabled")]
    public bool? NetworkInspectionSystemEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productStatus")]
    public WindowsDefenderProductStatusConstant? ProductStatus { get; set; }

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

    [JsonPropertyName("tamperProtectionEnabled")]
    public bool? TamperProtectionEnabled { get; set; }
}
