// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdateForBusinessConfigurationModel
{
    [JsonPropertyName("allowWindows11Upgrade")]
    public bool? AllowWindows11Upgrade { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("autoRestartNotificationDismissal")]
    public AutoRestartNotificationDismissalMethodConstant? AutoRestartNotificationDismissal { get; set; }

    [JsonPropertyName("automaticUpdateMode")]
    public AutomaticUpdateModeConstant? AutomaticUpdateMode { get; set; }

    [JsonPropertyName("businessReadyUpdatesOnly")]
    public WindowsUpdateTypeConstant? BusinessReadyUpdatesOnly { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deadlineForFeatureUpdatesInDays")]
    public int? DeadlineForFeatureUpdatesInDays { get; set; }

    [JsonPropertyName("deadlineForQualityUpdatesInDays")]
    public int? DeadlineForQualityUpdatesInDays { get; set; }

    [JsonPropertyName("deadlineGracePeriodInDays")]
    public int? DeadlineGracePeriodInDays { get; set; }

    [JsonPropertyName("deliveryOptimizationMode")]
    public WindowsDeliveryOptimizationModeConstant? DeliveryOptimizationMode { get; set; }

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

    [JsonPropertyName("driversExcluded")]
    public bool? DriversExcluded { get; set; }

    [JsonPropertyName("engagedRestartDeadlineInDays")]
    public int? EngagedRestartDeadlineInDays { get; set; }

    [JsonPropertyName("engagedRestartSnoozeScheduleInDays")]
    public int? EngagedRestartSnoozeScheduleInDays { get; set; }

    [JsonPropertyName("engagedRestartTransitionScheduleInDays")]
    public int? EngagedRestartTransitionScheduleInDays { get; set; }

    [JsonPropertyName("featureUpdatesDeferralPeriodInDays")]
    public int? FeatureUpdatesDeferralPeriodInDays { get; set; }

    [JsonPropertyName("featureUpdatesPauseExpiryDateTime")]
    public DateTime? FeatureUpdatesPauseExpiryDateTime { get; set; }

    [JsonPropertyName("featureUpdatesPauseStartDate")]
    public DateTime? FeatureUpdatesPauseStartDate { get; set; }

    [JsonPropertyName("featureUpdatesPaused")]
    public bool? FeatureUpdatesPaused { get; set; }

    [JsonPropertyName("featureUpdatesRollbackStartDateTime")]
    public DateTime? FeatureUpdatesRollbackStartDateTime { get; set; }

    [JsonPropertyName("featureUpdatesRollbackWindowInDays")]
    public int? FeatureUpdatesRollbackWindowInDays { get; set; }

    [JsonPropertyName("featureUpdatesWillBeRolledBack")]
    public bool? FeatureUpdatesWillBeRolledBack { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("installationSchedule")]
    public WindowsUpdateInstallScheduleTypeModel? InstallationSchedule { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("microsoftUpdateServiceAllowed")]
    public bool? MicrosoftUpdateServiceAllowed { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("postponeRebootUntilAfterDeadline")]
    public bool? PostponeRebootUntilAfterDeadline { get; set; }

    [JsonPropertyName("prereleaseFeatures")]
    public PrereleaseFeaturesConstant? PrereleaseFeatures { get; set; }

    [JsonPropertyName("qualityUpdatesDeferralPeriodInDays")]
    public int? QualityUpdatesDeferralPeriodInDays { get; set; }

    [JsonPropertyName("qualityUpdatesPauseExpiryDateTime")]
    public DateTime? QualityUpdatesPauseExpiryDateTime { get; set; }

    [JsonPropertyName("qualityUpdatesPauseStartDate")]
    public DateTime? QualityUpdatesPauseStartDate { get; set; }

    [JsonPropertyName("qualityUpdatesPaused")]
    public bool? QualityUpdatesPaused { get; set; }

    [JsonPropertyName("qualityUpdatesRollbackStartDateTime")]
    public DateTime? QualityUpdatesRollbackStartDateTime { get; set; }

    [JsonPropertyName("qualityUpdatesWillBeRolledBack")]
    public bool? QualityUpdatesWillBeRolledBack { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("scheduleImminentRestartWarningInMinutes")]
    public int? ScheduleImminentRestartWarningInMinutes { get; set; }

    [JsonPropertyName("scheduleRestartWarningInHours")]
    public int? ScheduleRestartWarningInHours { get; set; }

    [JsonPropertyName("skipChecksBeforeRestart")]
    public bool? SkipChecksBeforeRestart { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("updateNotificationLevel")]
    public WindowsUpdateNotificationDisplayOptionConstant? UpdateNotificationLevel { get; set; }

    [JsonPropertyName("updateWeeks")]
    public WindowsUpdateForBusinessUpdateWeeksConstant? UpdateWeeks { get; set; }

    [JsonPropertyName("userPauseAccess")]
    public EnablementConstant? UserPauseAccess { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("userWindowsUpdateScanAccess")]
    public EnablementConstant? UserWindowsUpdateScanAccess { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
