// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AndroidGeneralDeviceConfigurationModel
{
    [JsonPropertyName("appsBlockClipboardSharing")]
    public bool? AppsBlockClipboardSharing { get; set; }

    [JsonPropertyName("appsBlockCopyPaste")]
    public bool? AppsBlockCopyPaste { get; set; }

    [JsonPropertyName("appsBlockYouTube")]
    public bool? AppsBlockYouTube { get; set; }

    [JsonPropertyName("appsHideList")]
    public List<AppListItemModel>? AppsHideList { get; set; }

    [JsonPropertyName("appsInstallAllowList")]
    public List<AppListItemModel>? AppsInstallAllowList { get; set; }

    [JsonPropertyName("appsLaunchBlockList")]
    public List<AppListItemModel>? AppsLaunchBlockList { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bluetoothBlocked")]
    public bool? BluetoothBlocked { get; set; }

    [JsonPropertyName("cameraBlocked")]
    public bool? CameraBlocked { get; set; }

    [JsonPropertyName("cellularBlockDataRoaming")]
    public bool? CellularBlockDataRoaming { get; set; }

    [JsonPropertyName("cellularBlockMessaging")]
    public bool? CellularBlockMessaging { get; set; }

    [JsonPropertyName("cellularBlockVoiceRoaming")]
    public bool? CellularBlockVoiceRoaming { get; set; }

    [JsonPropertyName("cellularBlockWiFiTethering")]
    public bool? CellularBlockWiFiTethering { get; set; }

    [JsonPropertyName("compliantAppListType")]
    public AndroidGeneralDeviceConfigurationCompliantAppListTypeConstant? CompliantAppListType { get; set; }

    [JsonPropertyName("compliantAppsList")]
    public List<AppListItemModel>? CompliantAppsList { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceSharingAllowed")]
    public bool? DeviceSharingAllowed { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("diagnosticDataBlockSubmission")]
    public bool? DiagnosticDataBlockSubmission { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("factoryResetBlocked")]
    public bool? FactoryResetBlocked { get; set; }

    [JsonPropertyName("googleAccountBlockAutoSync")]
    public bool? GoogleAccountBlockAutoSync { get; set; }

    [JsonPropertyName("googlePlayStoreBlocked")]
    public bool? GooglePlayStoreBlocked { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("kioskModeApps")]
    public List<AppListItemModel>? KioskModeApps { get; set; }

    [JsonPropertyName("kioskModeBlockSleepButton")]
    public bool? KioskModeBlockSleepButton { get; set; }

    [JsonPropertyName("kioskModeBlockVolumeButtons")]
    public bool? KioskModeBlockVolumeButtons { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("locationServicesBlocked")]
    public bool? LocationServicesBlocked { get; set; }

    [JsonPropertyName("nfcBlocked")]
    public bool? NfcBlocked { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBlockFingerprintUnlock")]
    public bool? PasswordBlockFingerprintUnlock { get; set; }

    [JsonPropertyName("passwordBlockTrustAgents")]
    public bool? PasswordBlockTrustAgents { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeScreenTimeout")]
    public int? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public AndroidGeneralDeviceConfigurationPasswordRequiredTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("passwordSignInFailureCountBeforeFactoryReset")]
    public int? PasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("powerOffBlocked")]
    public bool? PowerOffBlocked { get; set; }

    [JsonPropertyName("screenCaptureBlocked")]
    public bool? ScreenCaptureBlocked { get; set; }

    [JsonPropertyName("securityRequireVerifyApps")]
    public bool? SecurityRequireVerifyApps { get; set; }

    [JsonPropertyName("storageBlockGoogleBackup")]
    public bool? StorageBlockGoogleBackup { get; set; }

    [JsonPropertyName("storageBlockRemovableStorage")]
    public bool? StorageBlockRemovableStorage { get; set; }

    [JsonPropertyName("storageRequireDeviceEncryption")]
    public bool? StorageRequireDeviceEncryption { get; set; }

    [JsonPropertyName("storageRequireRemovableStorageEncryption")]
    public bool? StorageRequireRemovableStorageEncryption { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("voiceAssistantBlocked")]
    public bool? VoiceAssistantBlocked { get; set; }

    [JsonPropertyName("voiceDialingBlocked")]
    public bool? VoiceDialingBlocked { get; set; }

    [JsonPropertyName("webBrowserBlockAutofill")]
    public bool? WebBrowserBlockAutofill { get; set; }

    [JsonPropertyName("webBrowserBlockJavaScript")]
    public bool? WebBrowserBlockJavaScript { get; set; }

    [JsonPropertyName("webBrowserBlockPopups")]
    public bool? WebBrowserBlockPopups { get; set; }

    [JsonPropertyName("webBrowserBlocked")]
    public bool? WebBrowserBlocked { get; set; }

    [JsonPropertyName("webBrowserCookieSettings")]
    public AndroidGeneralDeviceConfigurationWebBrowserCookieSettingsConstant? WebBrowserCookieSettings { get; set; }

    [JsonPropertyName("wiFiBlocked")]
    public bool? WiFiBlocked { get; set; }
}
