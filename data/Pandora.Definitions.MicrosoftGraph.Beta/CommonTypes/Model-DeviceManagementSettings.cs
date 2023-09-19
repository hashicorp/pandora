// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementSettingsModel
{
    [JsonPropertyName("androidDeviceAdministratorEnrollmentEnabled")]
    public bool? AndroidDeviceAdministratorEnrollmentEnabled { get; set; }

    [JsonPropertyName("derivedCredentialProvider")]
    public DeviceManagementSettingsDerivedCredentialProviderConstant? DerivedCredentialProvider { get; set; }

    [JsonPropertyName("derivedCredentialUrl")]
    public string? DerivedCredentialUrl { get; set; }

    [JsonPropertyName("deviceComplianceCheckinThresholdDays")]
    public int? DeviceComplianceCheckinThresholdDays { get; set; }

    [JsonPropertyName("deviceInactivityBeforeRetirementInDay")]
    public int? DeviceInactivityBeforeRetirementInDay { get; set; }

    [JsonPropertyName("enableAutopilotDiagnostics")]
    public bool? EnableAutopilotDiagnostics { get; set; }

    [JsonPropertyName("enableDeviceGroupMembershipReport")]
    public bool? EnableDeviceGroupMembershipReport { get; set; }

    [JsonPropertyName("enableEnhancedTroubleshootingExperience")]
    public bool? EnableEnhancedTroubleshootingExperience { get; set; }

    [JsonPropertyName("enableLogCollection")]
    public bool? EnableLogCollection { get; set; }

    [JsonPropertyName("enhancedJailBreak")]
    public bool? EnhancedJailBreak { get; set; }

    [JsonPropertyName("ignoreDevicesForUnsupportedSettingsEnabled")]
    public bool? IgnoreDevicesForUnsupportedSettingsEnabled { get; set; }

    [JsonPropertyName("isScheduledActionEnabled")]
    public bool? IsScheduledActionEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("secureByDefault")]
    public bool? SecureByDefault { get; set; }
}
