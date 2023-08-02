// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsKioskConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleDeviceMode")]
    public DeviceManagementApplicabilityRuleDeviceModeModel? DeviceManagementApplicabilityRuleDeviceMode { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleOsEdition")]
    public DeviceManagementApplicabilityRuleOsEditionModel? DeviceManagementApplicabilityRuleOsEdition { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleOsVersion")]
    public DeviceManagementApplicabilityRuleOsVersionModel? DeviceManagementApplicabilityRuleOsVersion { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("edgeKioskEnablePublicBrowsing")]
    public bool? EdgeKioskEnablePublicBrowsing { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("kioskBrowserBlockedURLs")]
    public List<string>? KioskBrowserBlockedURLs { get; set; }

    [JsonPropertyName("kioskBrowserBlockedUrlExceptions")]
    public List<string>? KioskBrowserBlockedUrlExceptions { get; set; }

    [JsonPropertyName("kioskBrowserDefaultUrl")]
    public string? KioskBrowserDefaultUrl { get; set; }

    [JsonPropertyName("kioskBrowserEnableEndSessionButton")]
    public bool? KioskBrowserEnableEndSessionButton { get; set; }

    [JsonPropertyName("kioskBrowserEnableHomeButton")]
    public bool? KioskBrowserEnableHomeButton { get; set; }

    [JsonPropertyName("kioskBrowserEnableNavigationButtons")]
    public bool? KioskBrowserEnableNavigationButtons { get; set; }

    [JsonPropertyName("kioskBrowserRestartOnIdleTimeInMinutes")]
    public int? KioskBrowserRestartOnIdleTimeInMinutes { get; set; }

    [JsonPropertyName("kioskProfiles")]
    public List<WindowsKioskProfileModel>? KioskProfiles { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("windowsKioskForceUpdateSchedule")]
    public WindowsKioskForceUpdateScheduleModel? WindowsKioskForceUpdateSchedule { get; set; }
}
