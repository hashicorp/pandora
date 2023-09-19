// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DeviceManagementModel
{
    [JsonPropertyName("applePushNotificationCertificate")]
    public ApplePushNotificationCertificateModel? ApplePushNotificationCertificate { get; set; }

    [JsonPropertyName("auditEvents")]
    public List<AuditEventModel>? AuditEvents { get; set; }

    [JsonPropertyName("complianceManagementPartners")]
    public List<ComplianceManagementPartnerModel>? ComplianceManagementPartners { get; set; }

    [JsonPropertyName("conditionalAccessSettings")]
    public OnPremisesConditionalAccessSettingsModel? ConditionalAccessSettings { get; set; }

    [JsonPropertyName("detectedApps")]
    public List<DetectedAppModel>? DetectedApps { get; set; }

    [JsonPropertyName("deviceCategories")]
    public List<DeviceCategoryModel>? DeviceCategories { get; set; }

    [JsonPropertyName("deviceCompliancePolicies")]
    public List<DeviceCompliancePolicyModel>? DeviceCompliancePolicies { get; set; }

    [JsonPropertyName("deviceCompliancePolicyDeviceStateSummary")]
    public DeviceCompliancePolicyDeviceStateSummaryModel? DeviceCompliancePolicyDeviceStateSummary { get; set; }

    [JsonPropertyName("deviceCompliancePolicySettingStateSummaries")]
    public List<DeviceCompliancePolicySettingStateSummaryModel>? DeviceCompliancePolicySettingStateSummaries { get; set; }

    [JsonPropertyName("deviceConfigurationDeviceStateSummaries")]
    public DeviceConfigurationDeviceStateSummaryModel? DeviceConfigurationDeviceStateSummaries { get; set; }

    [JsonPropertyName("deviceConfigurations")]
    public List<DeviceConfigurationModel>? DeviceConfigurations { get; set; }

    [JsonPropertyName("deviceEnrollmentConfigurations")]
    public List<DeviceEnrollmentConfigurationModel>? DeviceEnrollmentConfigurations { get; set; }

    [JsonPropertyName("deviceManagementPartners")]
    public List<DeviceManagementPartnerModel>? DeviceManagementPartners { get; set; }

    [JsonPropertyName("deviceProtectionOverview")]
    public DeviceProtectionOverviewModel? DeviceProtectionOverview { get; set; }

    [JsonPropertyName("exchangeConnectors")]
    public List<DeviceManagementExchangeConnectorModel>? ExchangeConnectors { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importedWindowsAutopilotDeviceIdentities")]
    public List<ImportedWindowsAutopilotDeviceIdentityModel>? ImportedWindowsAutopilotDeviceIdentities { get; set; }

    [JsonPropertyName("intuneAccountId")]
    public string? IntuneAccountId { get; set; }

    [JsonPropertyName("intuneBrand")]
    public IntuneBrandModel? IntuneBrand { get; set; }

    [JsonPropertyName("iosUpdateStatuses")]
    public List<IosUpdateDeviceStatusModel>? IosUpdateStatuses { get; set; }

    [JsonPropertyName("managedDeviceOverview")]
    public ManagedDeviceOverviewModel? ManagedDeviceOverview { get; set; }

    [JsonPropertyName("managedDevices")]
    public List<ManagedDeviceModel>? ManagedDevices { get; set; }

    [JsonPropertyName("mobileAppTroubleshootingEvents")]
    public List<MobileAppTroubleshootingEventModel>? MobileAppTroubleshootingEvents { get; set; }

    [JsonPropertyName("mobileThreatDefenseConnectors")]
    public List<MobileThreatDefenseConnectorModel>? MobileThreatDefenseConnectors { get; set; }

    [JsonPropertyName("notificationMessageTemplates")]
    public List<NotificationMessageTemplateModel>? NotificationMessageTemplates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remoteAssistancePartners")]
    public List<RemoteAssistancePartnerModel>? RemoteAssistancePartners { get; set; }

    [JsonPropertyName("reports")]
    public DeviceManagementReportsModel? Reports { get; set; }

    [JsonPropertyName("resourceOperations")]
    public List<ResourceOperationModel>? ResourceOperations { get; set; }

    [JsonPropertyName("roleAssignments")]
    public List<DeviceAndAppManagementRoleAssignmentModel>? RoleAssignments { get; set; }

    [JsonPropertyName("roleDefinitions")]
    public List<RoleDefinitionModel>? RoleDefinitions { get; set; }

    [JsonPropertyName("settings")]
    public DeviceManagementSettingsModel? Settings { get; set; }

    [JsonPropertyName("softwareUpdateStatusSummary")]
    public SoftwareUpdateStatusSummaryModel? SoftwareUpdateStatusSummary { get; set; }

    [JsonPropertyName("subscriptionState")]
    public DeviceManagementSubscriptionStateConstant? SubscriptionState { get; set; }

    [JsonPropertyName("telecomExpenseManagementPartners")]
    public List<TelecomExpenseManagementPartnerModel>? TelecomExpenseManagementPartners { get; set; }

    [JsonPropertyName("termsAndConditions")]
    public List<TermsAndConditionsModel>? TermsAndConditions { get; set; }

    [JsonPropertyName("troubleshootingEvents")]
    public List<DeviceManagementTroubleshootingEventModel>? TroubleshootingEvents { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthApplicationPerformance")]
    public List<UserExperienceAnalyticsAppHealthApplicationPerformanceModel>? UserExperienceAnalyticsAppHealthApplicationPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthApplicationPerformanceByAppVersionDetails")]
    public List<UserExperienceAnalyticsAppHealthAppPerformanceByAppVersionDetailsModel>? UserExperienceAnalyticsAppHealthApplicationPerformanceByAppVersionDetails { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthApplicationPerformanceByAppVersionDeviceId")]
    public List<UserExperienceAnalyticsAppHealthAppPerformanceByAppVersionDeviceIdModel>? UserExperienceAnalyticsAppHealthApplicationPerformanceByAppVersionDeviceId { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthApplicationPerformanceByOSVersion")]
    public List<UserExperienceAnalyticsAppHealthAppPerformanceByOSVersionModel>? UserExperienceAnalyticsAppHealthApplicationPerformanceByOSVersion { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthDeviceModelPerformance")]
    public List<UserExperienceAnalyticsAppHealthDeviceModelPerformanceModel>? UserExperienceAnalyticsAppHealthDeviceModelPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthDevicePerformance")]
    public List<UserExperienceAnalyticsAppHealthDevicePerformanceModel>? UserExperienceAnalyticsAppHealthDevicePerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthDevicePerformanceDetails")]
    public List<UserExperienceAnalyticsAppHealthDevicePerformanceDetailsModel>? UserExperienceAnalyticsAppHealthDevicePerformanceDetails { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthOSVersionPerformance")]
    public List<UserExperienceAnalyticsAppHealthOSVersionPerformanceModel>? UserExperienceAnalyticsAppHealthOSVersionPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthOverview")]
    public UserExperienceAnalyticsCategoryModel? UserExperienceAnalyticsAppHealthOverview { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBaselines")]
    public List<UserExperienceAnalyticsBaselineModel>? UserExperienceAnalyticsBaselines { get; set; }

    [JsonPropertyName("userExperienceAnalyticsCategories")]
    public List<UserExperienceAnalyticsCategoryModel>? UserExperienceAnalyticsCategories { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDevicePerformance")]
    public List<UserExperienceAnalyticsDevicePerformanceModel>? UserExperienceAnalyticsDevicePerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceScores")]
    public List<UserExperienceAnalyticsDeviceScoresModel>? UserExperienceAnalyticsDeviceScores { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceStartupHistory")]
    public List<UserExperienceAnalyticsDeviceStartupHistoryModel>? UserExperienceAnalyticsDeviceStartupHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceStartupProcesses")]
    public List<UserExperienceAnalyticsDeviceStartupProcessModel>? UserExperienceAnalyticsDeviceStartupProcesses { get; set; }

    [JsonPropertyName("userExperienceAnalyticsMetricHistory")]
    public List<UserExperienceAnalyticsMetricHistoryModel>? UserExperienceAnalyticsMetricHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsModelScores")]
    public List<UserExperienceAnalyticsModelScoresModel>? UserExperienceAnalyticsModelScores { get; set; }

    [JsonPropertyName("userExperienceAnalyticsOverview")]
    public UserExperienceAnalyticsOverviewModel? UserExperienceAnalyticsOverview { get; set; }

    [JsonPropertyName("userExperienceAnalyticsScoreHistory")]
    public List<UserExperienceAnalyticsScoreHistoryModel>? UserExperienceAnalyticsScoreHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsSettings")]
    public UserExperienceAnalyticsSettingsModel? UserExperienceAnalyticsSettings { get; set; }

    [JsonPropertyName("userExperienceAnalyticsWorkFromAnywhereHardwareReadinessMetric")]
    public UserExperienceAnalyticsWorkFromAnywhereHardwareReadinessMetricModel? UserExperienceAnalyticsWorkFromAnywhereHardwareReadinessMetric { get; set; }

    [JsonPropertyName("userExperienceAnalyticsWorkFromAnywhereMetrics")]
    public List<UserExperienceAnalyticsWorkFromAnywhereMetricModel>? UserExperienceAnalyticsWorkFromAnywhereMetrics { get; set; }

    [JsonPropertyName("userExperienceAnalyticsWorkFromAnywhereModelPerformance")]
    public List<UserExperienceAnalyticsWorkFromAnywhereModelPerformanceModel>? UserExperienceAnalyticsWorkFromAnywhereModelPerformance { get; set; }

    [JsonPropertyName("windowsAutopilotDeviceIdentities")]
    public List<WindowsAutopilotDeviceIdentityModel>? WindowsAutopilotDeviceIdentities { get; set; }

    [JsonPropertyName("windowsInformationProtectionAppLearningSummaries")]
    public List<WindowsInformationProtectionAppLearningSummaryModel>? WindowsInformationProtectionAppLearningSummaries { get; set; }

    [JsonPropertyName("windowsInformationProtectionNetworkLearningSummaries")]
    public List<WindowsInformationProtectionNetworkLearningSummaryModel>? WindowsInformationProtectionNetworkLearningSummaries { get; set; }

    [JsonPropertyName("windowsMalwareInformation")]
    public List<WindowsMalwareInformationModel>? WindowsMalwareInformation { get; set; }

    [JsonPropertyName("windowsMalwareOverview")]
    public WindowsMalwareOverviewModel? WindowsMalwareOverview { get; set; }
}
