// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsWorkFromAnywhereDevicesSummaryModel
{
    [JsonPropertyName("autopilotDevicesSummary")]
    public UserExperienceAnalyticsAutopilotDevicesSummaryModel? AutopilotDevicesSummary { get; set; }

    [JsonPropertyName("cloudIdentityDevicesSummary")]
    public UserExperienceAnalyticsCloudIdentityDevicesSummaryModel? CloudIdentityDevicesSummary { get; set; }

    [JsonPropertyName("cloudManagementDevicesSummary")]
    public UserExperienceAnalyticsCloudManagementDevicesSummaryModel? CloudManagementDevicesSummary { get; set; }

    [JsonPropertyName("coManagedDevices")]
    public int? CoManagedDevices { get; set; }

    [JsonPropertyName("devicesNotAutopilotRegistered")]
    public int? DevicesNotAutopilotRegistered { get; set; }

    [JsonPropertyName("devicesWithoutAutopilotProfileAssigned")]
    public int? DevicesWithoutAutopilotProfileAssigned { get; set; }

    [JsonPropertyName("devicesWithoutCloudIdentity")]
    public int? DevicesWithoutCloudIdentity { get; set; }

    [JsonPropertyName("intuneDevices")]
    public int? IntuneDevices { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantAttachDevices")]
    public int? TenantAttachDevices { get; set; }

    [JsonPropertyName("totalDevices")]
    public int? TotalDevices { get; set; }

    [JsonPropertyName("unsupportedOSversionDevices")]
    public int? UnsupportedOSversionDevices { get; set; }

    [JsonPropertyName("windows10Devices")]
    public int? Windows10Devices { get; set; }

    [JsonPropertyName("windows10DevicesSummary")]
    public UserExperienceAnalyticsWindows10DevicesSummaryModel? Windows10DevicesSummary { get; set; }

    [JsonPropertyName("windows10DevicesWithoutTenantAttach")]
    public int? Windows10DevicesWithoutTenantAttach { get; set; }
}
