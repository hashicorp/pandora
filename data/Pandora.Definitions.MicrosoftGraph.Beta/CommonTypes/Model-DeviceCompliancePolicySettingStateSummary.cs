// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceCompliancePolicySettingStateSummaryModel
{
    [JsonPropertyName("conflictDeviceCount")]
    public int? ConflictDeviceCount { get; set; }

    [JsonPropertyName("errorDeviceCount")]
    public int? ErrorDeviceCount { get; set; }

    [JsonPropertyName("failedDeviceCount")]
    public int? FailedDeviceCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intuneAccountId")]
    public string? IntuneAccountId { get; set; }

    [JsonPropertyName("intuneSettingId")]
    public string? IntuneSettingId { get; set; }

    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("notApplicableDeviceCount")]
    public int? NotApplicableDeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingDeviceCount")]
    public int? PendingDeviceCount { get; set; }

    [JsonPropertyName("policyType")]
    public string? PolicyType { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }

    [JsonPropertyName("succeededDeviceCount")]
    public int? SucceededDeviceCount { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
