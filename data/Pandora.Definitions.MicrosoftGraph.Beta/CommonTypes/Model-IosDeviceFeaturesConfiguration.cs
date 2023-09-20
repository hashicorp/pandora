// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosDeviceFeaturesConfigurationModel
{
    [JsonPropertyName("airPrintDestinations")]
    public List<AirPrintDestinationModel>? AirPrintDestinations { get; set; }

    [JsonPropertyName("assetTagTemplate")]
    public string? AssetTagTemplate { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("contentFilterSettings")]
    public IosWebContentFilterBaseModel? ContentFilterSettings { get; set; }

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

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("homeScreenDockIcons")]
    public List<IosHomeScreenItemModel>? HomeScreenDockIcons { get; set; }

    [JsonPropertyName("homeScreenGridHeight")]
    public int? HomeScreenGridHeight { get; set; }

    [JsonPropertyName("homeScreenGridWidth")]
    public int? HomeScreenGridWidth { get; set; }

    [JsonPropertyName("homeScreenPages")]
    public List<IosHomeScreenPageModel>? HomeScreenPages { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityCertificateForClientAuthentication")]
    public IosCertificateProfileBaseModel? IdentityCertificateForClientAuthentication { get; set; }

    [JsonPropertyName("iosSingleSignOnExtension")]
    public IosSingleSignOnExtensionModel? IosSingleSignOnExtension { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lockScreenFootnote")]
    public string? LockScreenFootnote { get; set; }

    [JsonPropertyName("notificationSettings")]
    public List<IosNotificationSettingsModel>? NotificationSettings { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("singleSignOnExtension")]
    public SingleSignOnExtensionModel? SingleSignOnExtension { get; set; }

    [JsonPropertyName("singleSignOnExtensionPkinitCertificate")]
    public IosCertificateProfileBaseModel? SingleSignOnExtensionPkinitCertificate { get; set; }

    [JsonPropertyName("singleSignOnSettings")]
    public IosSingleSignOnSettingsModel? SingleSignOnSettings { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("wallpaperDisplayLocation")]
    public IosDeviceFeaturesConfigurationWallpaperDisplayLocationConstant? WallpaperDisplayLocation { get; set; }

    [JsonPropertyName("wallpaperImage")]
    public MimeContentModel? WallpaperImage { get; set; }
}
