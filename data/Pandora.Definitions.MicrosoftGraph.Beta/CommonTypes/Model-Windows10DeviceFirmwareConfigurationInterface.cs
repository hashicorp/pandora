// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10DeviceFirmwareConfigurationInterfaceModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bluetooth")]
    public EnablementConstant? Bluetooth { get; set; }

    [JsonPropertyName("bootFromBuiltInNetworkAdapters")]
    public EnablementConstant? BootFromBuiltInNetworkAdapters { get; set; }

    [JsonPropertyName("bootFromExternalMedia")]
    public EnablementConstant? BootFromExternalMedia { get; set; }

    [JsonPropertyName("cameras")]
    public EnablementConstant? Cameras { get; set; }

    [JsonPropertyName("changeUefiSettingsPermission")]
    public ChangeUefiSettingsPermissionConstant? ChangeUefiSettingsPermission { get; set; }

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

    [JsonPropertyName("frontCamera")]
    public EnablementConstant? FrontCamera { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("infraredCamera")]
    public EnablementConstant? InfraredCamera { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("microphone")]
    public EnablementConstant? Microphone { get; set; }

    [JsonPropertyName("microphonesAndSpeakers")]
    public EnablementConstant? MicrophonesAndSpeakers { get; set; }

    [JsonPropertyName("nearFieldCommunication")]
    public EnablementConstant? NearFieldCommunication { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("radios")]
    public EnablementConstant? Radios { get; set; }

    [JsonPropertyName("rearCamera")]
    public EnablementConstant? RearCamera { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("sdCard")]
    public EnablementConstant? SdCard { get; set; }

    [JsonPropertyName("simultaneousMultiThreading")]
    public EnablementConstant? SimultaneousMultiThreading { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("usbTypeAPort")]
    public EnablementConstant? UsbTypeAPort { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("virtualizationOfCpuAndIO")]
    public EnablementConstant? VirtualizationOfCpuAndIO { get; set; }

    [JsonPropertyName("wakeOnLAN")]
    public EnablementConstant? WakeOnLAN { get; set; }

    [JsonPropertyName("wakeOnPower")]
    public EnablementConstant? WakeOnPower { get; set; }

    [JsonPropertyName("wiFi")]
    public EnablementConstant? WiFi { get; set; }

    [JsonPropertyName("windowsPlatformBinaryTable")]
    public EnablementConstant? WindowsPlatformBinaryTable { get; set; }

    [JsonPropertyName("wirelessWideAreaNetwork")]
    public EnablementConstant? WirelessWideAreaNetwork { get; set; }
}
