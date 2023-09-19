// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WindowsPhone81GeneralConfigurationModel
{
    [JsonPropertyName("applyOnlyToWindowsPhone81")]
    public bool? ApplyOnlyToWindowsPhone81 { get; set; }

    [JsonPropertyName("appsBlockCopyPaste")]
    public bool? AppsBlockCopyPaste { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bluetoothBlocked")]
    public bool? BluetoothBlocked { get; set; }

    [JsonPropertyName("cameraBlocked")]
    public bool? CameraBlocked { get; set; }

    [JsonPropertyName("cellularBlockWifiTethering")]
    public bool? CellularBlockWifiTethering { get; set; }

    [JsonPropertyName("compliantAppListType")]
    public WindowsPhone81GeneralConfigurationCompliantAppListTypeConstant? CompliantAppListType { get; set; }

    [JsonPropertyName("compliantAppsList")]
    public List<AppListItemModel>? CompliantAppsList { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("diagnosticDataBlockSubmission")]
    public bool? DiagnosticDataBlockSubmission { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("emailBlockAddingAccounts")]
    public bool? EmailBlockAddingAccounts { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("locationServicesBlocked")]
    public bool? LocationServicesBlocked { get; set; }

    [JsonPropertyName("microsoftAccountBlocked")]
    public bool? MicrosoftAccountBlocked { get; set; }

    [JsonPropertyName("nfcBlocked")]
    public bool? NfcBlocked { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBlockSimple")]
    public bool? PasswordBlockSimple { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumCharacterSetCount")]
    public int? PasswordMinimumCharacterSetCount { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeScreenTimeout")]
    public int? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public WindowsPhone81GeneralConfigurationPasswordRequiredTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("passwordSignInFailureCountBeforeFactoryReset")]
    public int? PasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("screenCaptureBlocked")]
    public bool? ScreenCaptureBlocked { get; set; }

    [JsonPropertyName("storageBlockRemovableStorage")]
    public bool? StorageBlockRemovableStorage { get; set; }

    [JsonPropertyName("storageRequireEncryption")]
    public bool? StorageRequireEncryption { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("webBrowserBlocked")]
    public bool? WebBrowserBlocked { get; set; }

    [JsonPropertyName("wifiBlockAutomaticConnectHotspots")]
    public bool? WifiBlockAutomaticConnectHotspots { get; set; }

    [JsonPropertyName("wifiBlockHotspotReporting")]
    public bool? WifiBlockHotspotReporting { get; set; }

    [JsonPropertyName("wifiBlocked")]
    public bool? WifiBlocked { get; set; }

    [JsonPropertyName("windowsStoreBlocked")]
    public bool? WindowsStoreBlocked { get; set; }
}
