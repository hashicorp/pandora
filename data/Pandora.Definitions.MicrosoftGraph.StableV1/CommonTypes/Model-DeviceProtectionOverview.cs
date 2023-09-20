// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DeviceProtectionOverviewModel
{
    [JsonPropertyName("cleanDeviceCount")]
    public int? CleanDeviceCount { get; set; }

    [JsonPropertyName("criticalFailuresDeviceCount")]
    public int? CriticalFailuresDeviceCount { get; set; }

    [JsonPropertyName("inactiveThreatAgentDeviceCount")]
    public int? InactiveThreatAgentDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingFullScanDeviceCount")]
    public int? PendingFullScanDeviceCount { get; set; }

    [JsonPropertyName("pendingManualStepsDeviceCount")]
    public int? PendingManualStepsDeviceCount { get; set; }

    [JsonPropertyName("pendingOfflineScanDeviceCount")]
    public int? PendingOfflineScanDeviceCount { get; set; }

    [JsonPropertyName("pendingQuickScanDeviceCount")]
    public int? PendingQuickScanDeviceCount { get; set; }

    [JsonPropertyName("pendingRestartDeviceCount")]
    public int? PendingRestartDeviceCount { get; set; }

    [JsonPropertyName("pendingSignatureUpdateDeviceCount")]
    public int? PendingSignatureUpdateDeviceCount { get; set; }

    [JsonPropertyName("totalReportedDeviceCount")]
    public int? TotalReportedDeviceCount { get; set; }

    [JsonPropertyName("unknownStateThreatAgentDeviceCount")]
    public int? UnknownStateThreatAgentDeviceCount { get; set; }
}
