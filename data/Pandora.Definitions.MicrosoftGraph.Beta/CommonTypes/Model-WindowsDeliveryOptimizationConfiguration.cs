// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsDeliveryOptimizationConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("backgroundDownloadFromHttpDelayInSeconds")]
    public int? BackgroundDownloadFromHttpDelayInSeconds { get; set; }

    [JsonPropertyName("bandwidthMode")]
    public DeliveryOptimizationBandwidthModel? BandwidthMode { get; set; }

    [JsonPropertyName("cacheServerBackgroundDownloadFallbackToHttpDelayInSeconds")]
    public int? CacheServerBackgroundDownloadFallbackToHttpDelayInSeconds { get; set; }

    [JsonPropertyName("cacheServerForegroundDownloadFallbackToHttpDelayInSeconds")]
    public int? CacheServerForegroundDownloadFallbackToHttpDelayInSeconds { get; set; }

    [JsonPropertyName("cacheServerHostNames")]
    public List<string>? CacheServerHostNames { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deliveryOptimizationMode")]
    public WindowsDeliveryOptimizationConfigurationDeliveryOptimizationModeConstant? DeliveryOptimizationMode { get; set; }

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

    [JsonPropertyName("foregroundDownloadFromHttpDelayInSeconds")]
    public int? ForegroundDownloadFromHttpDelayInSeconds { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("groupIdSource")]
    public DeliveryOptimizationGroupIdSourceModel? GroupIdSource { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maximumCacheAgeInDays")]
    public int? MaximumCacheAgeInDays { get; set; }

    [JsonPropertyName("maximumCacheSize")]
    public DeliveryOptimizationMaxCacheSizeModel? MaximumCacheSize { get; set; }

    [JsonPropertyName("minimumBatteryPercentageAllowedToUpload")]
    public int? MinimumBatteryPercentageAllowedToUpload { get; set; }

    [JsonPropertyName("minimumDiskSizeAllowedToPeerInGigabytes")]
    public int? MinimumDiskSizeAllowedToPeerInGigabytes { get; set; }

    [JsonPropertyName("minimumFileSizeToCacheInMegabytes")]
    public int? MinimumFileSizeToCacheInMegabytes { get; set; }

    [JsonPropertyName("minimumRamAllowedToPeerInGigabytes")]
    public int? MinimumRamAllowedToPeerInGigabytes { get; set; }

    [JsonPropertyName("modifyCacheLocation")]
    public string? ModifyCacheLocation { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("restrictPeerSelectionBy")]
    public WindowsDeliveryOptimizationConfigurationRestrictPeerSelectionByConstant? RestrictPeerSelectionBy { get; set; }

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

    [JsonPropertyName("vpnPeerCaching")]
    public WindowsDeliveryOptimizationConfigurationVpnPeerCachingConstant? VpnPeerCaching { get; set; }
}
