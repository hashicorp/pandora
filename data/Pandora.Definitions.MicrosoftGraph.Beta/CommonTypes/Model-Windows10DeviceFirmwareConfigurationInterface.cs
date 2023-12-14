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
    public Windows10DeviceFirmwareConfigurationInterfaceBluetoothConstant? Bluetooth { get; set; }

    [JsonPropertyName("bootFromBuiltInNetworkAdapters")]
    public Windows10DeviceFirmwareConfigurationInterfaceBootFromBuiltInNetworkAdaptersConstant? BootFromBuiltInNetworkAdapters { get; set; }

    [JsonPropertyName("bootFromExternalMedia")]
    public Windows10DeviceFirmwareConfigurationInterfaceBootFromExternalMediaConstant? BootFromExternalMedia { get; set; }

    [JsonPropertyName("cameras")]
    public Windows10DeviceFirmwareConfigurationInterfaceCamerasConstant? Cameras { get; set; }

    [JsonPropertyName("changeUefiSettingsPermission")]
    public Windows10DeviceFirmwareConfigurationInterfaceChangeUefiSettingsPermissionConstant? ChangeUefiSettingsPermission { get; set; }

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
    public Windows10DeviceFirmwareConfigurationInterfaceFrontCameraConstant? FrontCamera { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("infraredCamera")]
    public Windows10DeviceFirmwareConfigurationInterfaceInfraredCameraConstant? InfraredCamera { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("microphone")]
    public Windows10DeviceFirmwareConfigurationInterfaceMicrophoneConstant? Microphone { get; set; }

    [JsonPropertyName("microphonesAndSpeakers")]
    public Windows10DeviceFirmwareConfigurationInterfaceMicrophonesAndSpeakersConstant? MicrophonesAndSpeakers { get; set; }

    [JsonPropertyName("nearFieldCommunication")]
    public Windows10DeviceFirmwareConfigurationInterfaceNearFieldCommunicationConstant? NearFieldCommunication { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("radios")]
    public Windows10DeviceFirmwareConfigurationInterfaceRadiosConstant? Radios { get; set; }

    [JsonPropertyName("rearCamera")]
    public Windows10DeviceFirmwareConfigurationInterfaceRearCameraConstant? RearCamera { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("sdCard")]
    public Windows10DeviceFirmwareConfigurationInterfaceSdCardConstant? SdCard { get; set; }

    [JsonPropertyName("simultaneousMultiThreading")]
    public Windows10DeviceFirmwareConfigurationInterfaceSimultaneousMultiThreadingConstant? SimultaneousMultiThreading { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("usbTypeAPort")]
    public Windows10DeviceFirmwareConfigurationInterfaceUsbTypeAPortConstant? UsbTypeAPort { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("virtualizationOfCpuAndIO")]
    public Windows10DeviceFirmwareConfigurationInterfaceVirtualizationOfCpuAndIOConstant? VirtualizationOfCpuAndIO { get; set; }

    [JsonPropertyName("wakeOnLAN")]
    public Windows10DeviceFirmwareConfigurationInterfaceWakeOnLANConstant? WakeOnLAN { get; set; }

    [JsonPropertyName("wakeOnPower")]
    public Windows10DeviceFirmwareConfigurationInterfaceWakeOnPowerConstant? WakeOnPower { get; set; }

    [JsonPropertyName("wiFi")]
    public Windows10DeviceFirmwareConfigurationInterfaceWiFiConstant? WiFi { get; set; }

    [JsonPropertyName("windowsPlatformBinaryTable")]
    public Windows10DeviceFirmwareConfigurationInterfaceWindowsPlatformBinaryTableConstant? WindowsPlatformBinaryTable { get; set; }

    [JsonPropertyName("wirelessWideAreaNetwork")]
    public Windows10DeviceFirmwareConfigurationInterfaceWirelessWideAreaNetworkConstant? WirelessWideAreaNetwork { get; set; }
}
