// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementModel
{
    [JsonPropertyName("accountMoveCompletionDateTime")]
    public DateTime? AccountMoveCompletionDateTime { get; set; }

    [JsonPropertyName("adminConsent")]
    public AdminConsentModel? AdminConsent { get; set; }

    [JsonPropertyName("advancedThreatProtectionOnboardingStateSummary")]
    public AdvancedThreatProtectionOnboardingStateSummaryModel? AdvancedThreatProtectionOnboardingStateSummary { get; set; }

    [JsonPropertyName("androidDeviceOwnerEnrollmentProfiles")]
    public List<AndroidDeviceOwnerEnrollmentProfileModel>? AndroidDeviceOwnerEnrollmentProfiles { get; set; }

    [JsonPropertyName("androidForWorkAppConfigurationSchemas")]
    public List<AndroidForWorkAppConfigurationSchemaModel>? AndroidForWorkAppConfigurationSchemas { get; set; }

    [JsonPropertyName("androidForWorkEnrollmentProfiles")]
    public List<AndroidForWorkEnrollmentProfileModel>? AndroidForWorkEnrollmentProfiles { get; set; }

    [JsonPropertyName("androidForWorkSettings")]
    public AndroidForWorkSettingsModel? AndroidForWorkSettings { get; set; }

    [JsonPropertyName("androidManagedStoreAccountEnterpriseSettings")]
    public AndroidManagedStoreAccountEnterpriseSettingsModel? AndroidManagedStoreAccountEnterpriseSettings { get; set; }

    [JsonPropertyName("androidManagedStoreAppConfigurationSchemas")]
    public List<AndroidManagedStoreAppConfigurationSchemaModel>? AndroidManagedStoreAppConfigurationSchemas { get; set; }

    [JsonPropertyName("applePushNotificationCertificate")]
    public ApplePushNotificationCertificateModel? ApplePushNotificationCertificate { get; set; }

    [JsonPropertyName("appleUserInitiatedEnrollmentProfiles")]
    public List<AppleUserInitiatedEnrollmentProfileModel>? AppleUserInitiatedEnrollmentProfiles { get; set; }

    [JsonPropertyName("assignmentFilters")]
    public List<DeviceAndAppManagementAssignmentFilterModel>? AssignmentFilters { get; set; }

    [JsonPropertyName("auditEvents")]
    public List<AuditEventModel>? AuditEvents { get; set; }

    [JsonPropertyName("autopilotEvents")]
    public List<DeviceManagementAutopilotEventModel>? AutopilotEvents { get; set; }

    [JsonPropertyName("cartToClassAssociations")]
    public List<CartToClassAssociationModel>? CartToClassAssociations { get; set; }

    [JsonPropertyName("categories")]
    public List<DeviceManagementSettingCategoryModel>? Categories { get; set; }

    [JsonPropertyName("certificateConnectorDetails")]
    public List<CertificateConnectorDetailsModel>? CertificateConnectorDetails { get; set; }

    [JsonPropertyName("chromeOSOnboardingSettings")]
    public List<ChromeOSOnboardingSettingsModel>? ChromeOSOnboardingSettings { get; set; }

    [JsonPropertyName("cloudPCConnectivityIssues")]
    public List<CloudPCConnectivityIssueModel>? CloudPCConnectivityIssues { get; set; }

    [JsonPropertyName("comanagedDevices")]
    public List<ManagedDeviceModel>? ComanagedDevices { get; set; }

    [JsonPropertyName("comanagementEligibleDevices")]
    public List<ComanagementEligibleDeviceModel>? ComanagementEligibleDevices { get; set; }

    [JsonPropertyName("complianceCategories")]
    public List<DeviceManagementConfigurationCategoryModel>? ComplianceCategories { get; set; }

    [JsonPropertyName("complianceManagementPartners")]
    public List<ComplianceManagementPartnerModel>? ComplianceManagementPartners { get; set; }

    [JsonPropertyName("compliancePolicies")]
    public List<DeviceManagementCompliancePolicyModel>? CompliancePolicies { get; set; }

    [JsonPropertyName("complianceSettings")]
    public List<DeviceManagementConfigurationSettingDefinitionModel>? ComplianceSettings { get; set; }

    [JsonPropertyName("conditionalAccessSettings")]
    public OnPremisesConditionalAccessSettingsModel? ConditionalAccessSettings { get; set; }

    [JsonPropertyName("configManagerCollections")]
    public List<ConfigManagerCollectionModel>? ConfigManagerCollections { get; set; }

    [JsonPropertyName("configurationCategories")]
    public List<DeviceManagementConfigurationCategoryModel>? ConfigurationCategories { get; set; }

    [JsonPropertyName("configurationPolicies")]
    public List<DeviceManagementConfigurationPolicyModel>? ConfigurationPolicies { get; set; }

    [JsonPropertyName("configurationPolicyTemplates")]
    public List<DeviceManagementConfigurationPolicyTemplateModel>? ConfigurationPolicyTemplates { get; set; }

    [JsonPropertyName("configurationSettings")]
    public List<DeviceManagementConfigurationSettingDefinitionModel>? ConfigurationSettings { get; set; }

    [JsonPropertyName("connectorStatus")]
    public List<ConnectorStatusDetailsModel>? ConnectorStatus { get; set; }

    [JsonPropertyName("dataProcessorServiceForWindowsFeaturesOnboarding")]
    public DataProcessorServiceForWindowsFeaturesOnboardingModel? DataProcessorServiceForWindowsFeaturesOnboarding { get; set; }

    [JsonPropertyName("dataSharingConsents")]
    public List<DataSharingConsentModel>? DataSharingConsents { get; set; }

    [JsonPropertyName("depOnboardingSettings")]
    public List<DepOnboardingSettingModel>? DepOnboardingSettings { get; set; }

    [JsonPropertyName("derivedCredentials")]
    public List<DeviceManagementDerivedCredentialSettingsModel>? DerivedCredentials { get; set; }

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

    [JsonPropertyName("deviceComplianceReportSummarizationDateTime")]
    public DateTime? DeviceComplianceReportSummarizationDateTime { get; set; }

    [JsonPropertyName("deviceComplianceScripts")]
    public List<DeviceComplianceScriptModel>? DeviceComplianceScripts { get; set; }

    [JsonPropertyName("deviceConfigurationConflictSummary")]
    public List<DeviceConfigurationConflictSummaryModel>? DeviceConfigurationConflictSummary { get; set; }

    [JsonPropertyName("deviceConfigurationDeviceStateSummaries")]
    public DeviceConfigurationDeviceStateSummaryModel? DeviceConfigurationDeviceStateSummaries { get; set; }

    [JsonPropertyName("deviceConfigurationRestrictedAppsViolations")]
    public List<RestrictedAppsViolationModel>? DeviceConfigurationRestrictedAppsViolations { get; set; }

    [JsonPropertyName("deviceConfigurationUserStateSummaries")]
    public DeviceConfigurationUserStateSummaryModel? DeviceConfigurationUserStateSummaries { get; set; }

    [JsonPropertyName("deviceConfigurations")]
    public List<DeviceConfigurationModel>? DeviceConfigurations { get; set; }

    [JsonPropertyName("deviceConfigurationsAllManagedDeviceCertificateStates")]
    public List<ManagedAllDeviceCertificateStateModel>? DeviceConfigurationsAllManagedDeviceCertificateStates { get; set; }

    [JsonPropertyName("deviceCustomAttributeShellScripts")]
    public List<DeviceCustomAttributeShellScriptModel>? DeviceCustomAttributeShellScripts { get; set; }

    [JsonPropertyName("deviceEnrollmentConfigurations")]
    public List<DeviceEnrollmentConfigurationModel>? DeviceEnrollmentConfigurations { get; set; }

    [JsonPropertyName("deviceHealthScripts")]
    public List<DeviceHealthScriptModel>? DeviceHealthScripts { get; set; }

    [JsonPropertyName("deviceManagementPartners")]
    public List<DeviceManagementPartnerModel>? DeviceManagementPartners { get; set; }

    [JsonPropertyName("deviceManagementScripts")]
    public List<DeviceManagementScriptModel>? DeviceManagementScripts { get; set; }

    [JsonPropertyName("deviceProtectionOverview")]
    public DeviceProtectionOverviewModel? DeviceProtectionOverview { get; set; }

    [JsonPropertyName("deviceShellScripts")]
    public List<DeviceShellScriptModel>? DeviceShellScripts { get; set; }

    [JsonPropertyName("domainJoinConnectors")]
    public List<DeviceManagementDomainJoinConnectorModel>? DomainJoinConnectors { get; set; }

    [JsonPropertyName("elevationRequests")]
    public List<PrivilegeManagementElevationRequestModel>? ElevationRequests { get; set; }

    [JsonPropertyName("embeddedSIMActivationCodePools")]
    public List<EmbeddedSIMActivationCodePoolModel>? EmbeddedSIMActivationCodePools { get; set; }

    [JsonPropertyName("exchangeConnectors")]
    public List<DeviceManagementExchangeConnectorModel>? ExchangeConnectors { get; set; }

    [JsonPropertyName("exchangeOnPremisesPolicies")]
    public List<DeviceManagementExchangeOnPremisesPolicyModel>? ExchangeOnPremisesPolicies { get; set; }

    [JsonPropertyName("exchangeOnPremisesPolicy")]
    public DeviceManagementExchangeOnPremisesPolicyModel? ExchangeOnPremisesPolicy { get; set; }

    [JsonPropertyName("groupPolicyCategories")]
    public List<GroupPolicyCategoryModel>? GroupPolicyCategories { get; set; }

    [JsonPropertyName("groupPolicyConfigurations")]
    public List<GroupPolicyConfigurationModel>? GroupPolicyConfigurations { get; set; }

    [JsonPropertyName("groupPolicyDefinitionFiles")]
    public List<GroupPolicyDefinitionFileModel>? GroupPolicyDefinitionFiles { get; set; }

    [JsonPropertyName("groupPolicyDefinitions")]
    public List<GroupPolicyDefinitionModel>? GroupPolicyDefinitions { get; set; }

    [JsonPropertyName("groupPolicyMigrationReports")]
    public List<GroupPolicyMigrationReportModel>? GroupPolicyMigrationReports { get; set; }

    [JsonPropertyName("groupPolicyObjectFiles")]
    public List<GroupPolicyObjectFileModel>? GroupPolicyObjectFiles { get; set; }

    [JsonPropertyName("groupPolicyUploadedDefinitionFiles")]
    public List<GroupPolicyUploadedDefinitionFileModel>? GroupPolicyUploadedDefinitionFiles { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importedDeviceIdentities")]
    public List<ImportedDeviceIdentityModel>? ImportedDeviceIdentities { get; set; }

    [JsonPropertyName("importedWindowsAutopilotDeviceIdentities")]
    public List<ImportedWindowsAutopilotDeviceIdentityModel>? ImportedWindowsAutopilotDeviceIdentities { get; set; }

    [JsonPropertyName("intents")]
    public List<DeviceManagementIntentModel>? Intents { get; set; }

    [JsonPropertyName("intuneAccountId")]
    public string? IntuneAccountId { get; set; }

    [JsonPropertyName("intuneBrand")]
    public IntuneBrandModel? IntuneBrand { get; set; }

    [JsonPropertyName("intuneBrandingProfiles")]
    public List<IntuneBrandingProfileModel>? IntuneBrandingProfiles { get; set; }

    [JsonPropertyName("iosUpdateStatuses")]
    public List<IosUpdateDeviceStatusModel>? IosUpdateStatuses { get; set; }

    [JsonPropertyName("lastReportAggregationDateTime")]
    public DateTime? LastReportAggregationDateTime { get; set; }

    [JsonPropertyName("legacyPcManangementEnabled")]
    public bool? LegacyPcManangementEnabled { get; set; }

    [JsonPropertyName("macOSSoftwareUpdateAccountSummaries")]
    public List<MacOSSoftwareUpdateAccountSummaryModel>? MacOSSoftwareUpdateAccountSummaries { get; set; }

    [JsonPropertyName("managedDeviceCleanupSettings")]
    public ManagedDeviceCleanupSettingsModel? ManagedDeviceCleanupSettings { get; set; }

    [JsonPropertyName("managedDeviceEncryptionStates")]
    public List<ManagedDeviceEncryptionStateModel>? ManagedDeviceEncryptionStates { get; set; }

    [JsonPropertyName("managedDeviceOverview")]
    public ManagedDeviceOverviewModel? ManagedDeviceOverview { get; set; }

    [JsonPropertyName("managedDevices")]
    public List<ManagedDeviceModel>? ManagedDevices { get; set; }

    [JsonPropertyName("maximumDepTokens")]
    public int? MaximumDepTokens { get; set; }

    [JsonPropertyName("microsoftTunnelConfigurations")]
    public List<MicrosoftTunnelConfigurationModel>? MicrosoftTunnelConfigurations { get; set; }

    [JsonPropertyName("microsoftTunnelHealthThresholds")]
    public List<MicrosoftTunnelHealthThresholdModel>? MicrosoftTunnelHealthThresholds { get; set; }

    [JsonPropertyName("microsoftTunnelServerLogCollectionResponses")]
    public List<MicrosoftTunnelServerLogCollectionResponseModel>? MicrosoftTunnelServerLogCollectionResponses { get; set; }

    [JsonPropertyName("microsoftTunnelSites")]
    public List<MicrosoftTunnelSiteModel>? MicrosoftTunnelSites { get; set; }

    [JsonPropertyName("mobileAppTroubleshootingEvents")]
    public List<MobileAppTroubleshootingEventModel>? MobileAppTroubleshootingEvents { get; set; }

    [JsonPropertyName("mobileThreatDefenseConnectors")]
    public List<MobileThreatDefenseConnectorModel>? MobileThreatDefenseConnectors { get; set; }

    [JsonPropertyName("monitoring")]
    public DeviceManagementMonitoringModel? Monitoring { get; set; }

    [JsonPropertyName("ndesConnectors")]
    public List<NdesConnectorModel>? NdesConnectors { get; set; }

    [JsonPropertyName("notificationMessageTemplates")]
    public List<NotificationMessageTemplateModel>? NotificationMessageTemplates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("privilegeManagementElevations")]
    public List<PrivilegeManagementElevationModel>? PrivilegeManagementElevations { get; set; }

    [JsonPropertyName("remoteActionAudits")]
    public List<RemoteActionAuditModel>? RemoteActionAudits { get; set; }

    [JsonPropertyName("remoteAssistancePartners")]
    public List<RemoteAssistancePartnerModel>? RemoteAssistancePartners { get; set; }

    [JsonPropertyName("remoteAssistanceSettings")]
    public RemoteAssistanceSettingsModel? RemoteAssistanceSettings { get; set; }

    [JsonPropertyName("reports")]
    public DeviceManagementReportsModel? Reports { get; set; }

    [JsonPropertyName("resourceAccessProfiles")]
    public List<DeviceManagementResourceAccessProfileBaseModel>? ResourceAccessProfiles { get; set; }

    [JsonPropertyName("resourceOperations")]
    public List<ResourceOperationModel>? ResourceOperations { get; set; }

    [JsonPropertyName("reusablePolicySettings")]
    public List<DeviceManagementReusablePolicySettingModel>? ReusablePolicySettings { get; set; }

    [JsonPropertyName("reusableSettings")]
    public List<DeviceManagementConfigurationSettingDefinitionModel>? ReusableSettings { get; set; }

    [JsonPropertyName("roleAssignments")]
    public List<DeviceAndAppManagementRoleAssignmentModel>? RoleAssignments { get; set; }

    [JsonPropertyName("roleDefinitions")]
    public List<RoleDefinitionModel>? RoleDefinitions { get; set; }

    [JsonPropertyName("roleScopeTags")]
    public List<RoleScopeTagModel>? RoleScopeTags { get; set; }

    [JsonPropertyName("serviceNowConnections")]
    public List<ServiceNowConnectionModel>? ServiceNowConnections { get; set; }

    [JsonPropertyName("settingDefinitions")]
    public List<DeviceManagementSettingDefinitionModel>? SettingDefinitions { get; set; }

    [JsonPropertyName("settings")]
    public DeviceManagementSettingsModel? Settings { get; set; }

    [JsonPropertyName("softwareUpdateStatusSummary")]
    public SoftwareUpdateStatusSummaryModel? SoftwareUpdateStatusSummary { get; set; }

    [JsonPropertyName("subscriptionState")]
    public DeviceManagementSubscriptionStateConstant? SubscriptionState { get; set; }

    [JsonPropertyName("subscriptions")]
    public DeviceManagementSubscriptionsConstant? Subscriptions { get; set; }

    [JsonPropertyName("telecomExpenseManagementPartners")]
    public List<TelecomExpenseManagementPartnerModel>? TelecomExpenseManagementPartners { get; set; }

    [JsonPropertyName("templateInsights")]
    public List<DeviceManagementTemplateInsightsDefinitionModel>? TemplateInsights { get; set; }

    [JsonPropertyName("templateSettings")]
    public List<DeviceManagementConfigurationSettingTemplateModel>? TemplateSettings { get; set; }

    [JsonPropertyName("templates")]
    public List<DeviceManagementTemplateModel>? Templates { get; set; }

    [JsonPropertyName("tenantAttachRBAC")]
    public TenantAttachRBACModel? TenantAttachRBAC { get; set; }

    [JsonPropertyName("termsAndConditions")]
    public List<TermsAndConditionsModel>? TermsAndConditions { get; set; }

    [JsonPropertyName("troubleshootingEvents")]
    public List<DeviceManagementTroubleshootingEventModel>? TroubleshootingEvents { get; set; }

    [JsonPropertyName("unlicensedAdminstratorsEnabled")]
    public bool? UnlicensedAdminstratorsEnabled { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAnomaly")]
    public List<UserExperienceAnalyticsAnomalyModel>? UserExperienceAnalyticsAnomaly { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAnomalyCorrelationGroupOverview")]
    public List<UserExperienceAnalyticsAnomalyCorrelationGroupOverviewModel>? UserExperienceAnalyticsAnomalyCorrelationGroupOverview { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAnomalyDevice")]
    public List<UserExperienceAnalyticsAnomalyDeviceModel>? UserExperienceAnalyticsAnomalyDevice { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAnomalySeverityOverview")]
    public UserExperienceAnalyticsAnomalySeverityOverviewModel? UserExperienceAnalyticsAnomalySeverityOverview { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthApplicationPerformance")]
    public List<UserExperienceAnalyticsAppHealthApplicationPerformanceModel>? UserExperienceAnalyticsAppHealthApplicationPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsAppHealthApplicationPerformanceByAppVersion")]
    public List<UserExperienceAnalyticsAppHealthAppPerformanceByAppVersionModel>? UserExperienceAnalyticsAppHealthApplicationPerformanceByAppVersion { get; set; }

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

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthAppImpact")]
    public List<UserExperienceAnalyticsBatteryHealthAppImpactModel>? UserExperienceAnalyticsBatteryHealthAppImpact { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthCapacityDetails")]
    public UserExperienceAnalyticsBatteryHealthCapacityDetailsModel? UserExperienceAnalyticsBatteryHealthCapacityDetails { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthDeviceAppImpact")]
    public List<UserExperienceAnalyticsBatteryHealthDeviceAppImpactModel>? UserExperienceAnalyticsBatteryHealthDeviceAppImpact { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthDevicePerformance")]
    public List<UserExperienceAnalyticsBatteryHealthDevicePerformanceModel>? UserExperienceAnalyticsBatteryHealthDevicePerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthDeviceRuntimeHistory")]
    public List<UserExperienceAnalyticsBatteryHealthDeviceRuntimeHistoryModel>? UserExperienceAnalyticsBatteryHealthDeviceRuntimeHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthModelPerformance")]
    public List<UserExperienceAnalyticsBatteryHealthModelPerformanceModel>? UserExperienceAnalyticsBatteryHealthModelPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthOsPerformance")]
    public List<UserExperienceAnalyticsBatteryHealthOsPerformanceModel>? UserExperienceAnalyticsBatteryHealthOsPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsBatteryHealthRuntimeDetails")]
    public UserExperienceAnalyticsBatteryHealthRuntimeDetailsModel? UserExperienceAnalyticsBatteryHealthRuntimeDetails { get; set; }

    [JsonPropertyName("userExperienceAnalyticsCategories")]
    public List<UserExperienceAnalyticsCategoryModel>? UserExperienceAnalyticsCategories { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceMetricHistory")]
    public List<UserExperienceAnalyticsMetricHistoryModel>? UserExperienceAnalyticsDeviceMetricHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDevicePerformance")]
    public List<UserExperienceAnalyticsDevicePerformanceModel>? UserExperienceAnalyticsDevicePerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceScope")]
    public UserExperienceAnalyticsDeviceScopeModel? UserExperienceAnalyticsDeviceScope { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceScopes")]
    public List<UserExperienceAnalyticsDeviceScopeModel>? UserExperienceAnalyticsDeviceScopes { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceScores")]
    public List<UserExperienceAnalyticsDeviceScoresModel>? UserExperienceAnalyticsDeviceScores { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceStartupHistory")]
    public List<UserExperienceAnalyticsDeviceStartupHistoryModel>? UserExperienceAnalyticsDeviceStartupHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceStartupProcessPerformance")]
    public List<UserExperienceAnalyticsDeviceStartupProcessPerformanceModel>? UserExperienceAnalyticsDeviceStartupProcessPerformance { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceStartupProcesses")]
    public List<UserExperienceAnalyticsDeviceStartupProcessModel>? UserExperienceAnalyticsDeviceStartupProcesses { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDeviceTimelineEvent")]
    public List<UserExperienceAnalyticsDeviceTimelineEventModel>? UserExperienceAnalyticsDeviceTimelineEvent { get; set; }

    [JsonPropertyName("userExperienceAnalyticsDevicesWithoutCloudIdentity")]
    public List<UserExperienceAnalyticsDeviceWithoutCloudIdentityModel>? UserExperienceAnalyticsDevicesWithoutCloudIdentity { get; set; }

    [JsonPropertyName("userExperienceAnalyticsImpactingProcess")]
    public List<UserExperienceAnalyticsImpactingProcessModel>? UserExperienceAnalyticsImpactingProcess { get; set; }

    [JsonPropertyName("userExperienceAnalyticsMetricHistory")]
    public List<UserExperienceAnalyticsMetricHistoryModel>? UserExperienceAnalyticsMetricHistory { get; set; }

    [JsonPropertyName("userExperienceAnalyticsModelScores")]
    public List<UserExperienceAnalyticsModelScoresModel>? UserExperienceAnalyticsModelScores { get; set; }

    [JsonPropertyName("userExperienceAnalyticsNotAutopilotReadyDevice")]
    public List<UserExperienceAnalyticsNotAutopilotReadyDeviceModel>? UserExperienceAnalyticsNotAutopilotReadyDevice { get; set; }

    [JsonPropertyName("userExperienceAnalyticsOverview")]
    public UserExperienceAnalyticsOverviewModel? UserExperienceAnalyticsOverview { get; set; }

    [JsonPropertyName("userExperienceAnalyticsRemoteConnection")]
    public List<UserExperienceAnalyticsRemoteConnectionModel>? UserExperienceAnalyticsRemoteConnection { get; set; }

    [JsonPropertyName("userExperienceAnalyticsResourcePerformance")]
    public List<UserExperienceAnalyticsResourcePerformanceModel>? UserExperienceAnalyticsResourcePerformance { get; set; }

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

    [JsonPropertyName("userPfxCertificates")]
    public List<UserPFXCertificateModel>? UserPfxCertificates { get; set; }

    [JsonPropertyName("virtualEndpoint")]
    public VirtualEndpointModel? VirtualEndpoint { get; set; }

    [JsonPropertyName("windowsAutopilotDeploymentProfiles")]
    public List<WindowsAutopilotDeploymentProfileModel>? WindowsAutopilotDeploymentProfiles { get; set; }

    [JsonPropertyName("windowsAutopilotDeviceIdentities")]
    public List<WindowsAutopilotDeviceIdentityModel>? WindowsAutopilotDeviceIdentities { get; set; }

    [JsonPropertyName("windowsAutopilotSettings")]
    public WindowsAutopilotSettingsModel? WindowsAutopilotSettings { get; set; }

    [JsonPropertyName("windowsDriverUpdateProfiles")]
    public List<WindowsDriverUpdateProfileModel>? WindowsDriverUpdateProfiles { get; set; }

    [JsonPropertyName("windowsFeatureUpdateProfiles")]
    public List<WindowsFeatureUpdateProfileModel>? WindowsFeatureUpdateProfiles { get; set; }

    [JsonPropertyName("windowsInformationProtectionAppLearningSummaries")]
    public List<WindowsInformationProtectionAppLearningSummaryModel>? WindowsInformationProtectionAppLearningSummaries { get; set; }

    [JsonPropertyName("windowsInformationProtectionNetworkLearningSummaries")]
    public List<WindowsInformationProtectionNetworkLearningSummaryModel>? WindowsInformationProtectionNetworkLearningSummaries { get; set; }

    [JsonPropertyName("windowsMalwareInformation")]
    public List<WindowsMalwareInformationModel>? WindowsMalwareInformation { get; set; }

    [JsonPropertyName("windowsMalwareOverview")]
    public WindowsMalwareOverviewModel? WindowsMalwareOverview { get; set; }

    [JsonPropertyName("windowsQualityUpdateProfiles")]
    public List<WindowsQualityUpdateProfileModel>? WindowsQualityUpdateProfiles { get; set; }

    [JsonPropertyName("windowsUpdateCatalogItems")]
    public List<WindowsUpdateCatalogItemModel>? WindowsUpdateCatalogItems { get; set; }

    [JsonPropertyName("zebraFotaArtifacts")]
    public List<ZebraFotaArtifactModel>? ZebraFotaArtifacts { get; set; }

    [JsonPropertyName("zebraFotaConnector")]
    public ZebraFotaConnectorModel? ZebraFotaConnector { get; set; }

    [JsonPropertyName("zebraFotaDeployments")]
    public List<ZebraFotaDeploymentModel>? ZebraFotaDeployments { get; set; }
}
