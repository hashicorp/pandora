// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantModel
{
    [JsonPropertyName("aggregatedPolicyCompliances")]
    public List<AggregatedPolicyComplianceModel>? AggregatedPolicyCompliances { get; set; }

    [JsonPropertyName("appPerformances")]
    public List<AppPerformanceModel>? AppPerformances { get; set; }

    [JsonPropertyName("auditEvents")]
    public List<AuditEventModel>? AuditEvents { get; set; }

    [JsonPropertyName("cloudPcConnections")]
    public List<CloudPcConnectionModel>? CloudPcConnections { get; set; }

    [JsonPropertyName("cloudPcDevices")]
    public List<CloudPcDeviceModel>? CloudPcDevices { get; set; }

    [JsonPropertyName("cloudPcsOverview")]
    public List<CloudPcOverviewModel>? CloudPcsOverview { get; set; }

    [JsonPropertyName("conditionalAccessPolicyCoverages")]
    public List<ConditionalAccessPolicyCoverageModel>? ConditionalAccessPolicyCoverages { get; set; }

    [JsonPropertyName("credentialUserRegistrationsSummaries")]
    public List<CredentialUserRegistrationsSummaryModel>? CredentialUserRegistrationsSummaries { get; set; }

    [JsonPropertyName("deviceAppPerformances")]
    public List<DeviceAppPerformanceModel>? DeviceAppPerformances { get; set; }

    [JsonPropertyName("deviceCompliancePolicySettingStateSummaries")]
    public List<DeviceCompliancePolicySettingStateSummaryModel>? DeviceCompliancePolicySettingStateSummaries { get; set; }

    [JsonPropertyName("deviceHealthStatuses")]
    public List<DeviceHealthStatusModel>? DeviceHealthStatuses { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceComplianceTrends")]
    public List<ManagedDeviceComplianceTrendModel>? ManagedDeviceComplianceTrends { get; set; }

    [JsonPropertyName("managedDeviceCompliances")]
    public List<ManagedDeviceComplianceModel>? ManagedDeviceCompliances { get; set; }

    [JsonPropertyName("managedTenantAlertLogs")]
    public List<ManagedTenantAlertLogModel>? ManagedTenantAlertLogs { get; set; }

    [JsonPropertyName("managedTenantAlertRuleDefinitions")]
    public List<ManagedTenantAlertRuleDefinitionModel>? ManagedTenantAlertRuleDefinitions { get; set; }

    [JsonPropertyName("managedTenantAlertRules")]
    public List<ManagedTenantAlertRuleModel>? ManagedTenantAlertRules { get; set; }

    [JsonPropertyName("managedTenantAlerts")]
    public List<ManagedTenantAlertModel>? ManagedTenantAlerts { get; set; }

    [JsonPropertyName("managedTenantApiNotifications")]
    public List<ManagedTenantApiNotificationModel>? ManagedTenantApiNotifications { get; set; }

    [JsonPropertyName("managedTenantEmailNotifications")]
    public List<ManagedTenantEmailNotificationModel>? ManagedTenantEmailNotifications { get; set; }

    [JsonPropertyName("managedTenantTicketingEndpoints")]
    public List<ManagedTenantTicketingEndpointModel>? ManagedTenantTicketingEndpoints { get; set; }

    [JsonPropertyName("managementActionTenantDeploymentStatuses")]
    public List<ManagementActionTenantDeploymentStatusModel>? ManagementActionTenantDeploymentStatuses { get; set; }

    [JsonPropertyName("managementActions")]
    public List<ManagementActionModel>? ManagementActions { get; set; }

    [JsonPropertyName("managementIntents")]
    public List<ManagementIntentModel>? ManagementIntents { get; set; }

    [JsonPropertyName("managementTemplateCollectionTenantSummaries")]
    public List<ManagementTemplateCollectionTenantSummaryModel>? ManagementTemplateCollectionTenantSummaries { get; set; }

    [JsonPropertyName("managementTemplateCollections")]
    public List<ManagementTemplateCollectionModel>? ManagementTemplateCollections { get; set; }

    [JsonPropertyName("managementTemplateStepTenantSummaries")]
    public List<ManagementTemplateStepTenantSummaryModel>? ManagementTemplateStepTenantSummaries { get; set; }

    [JsonPropertyName("managementTemplateStepVersions")]
    public List<ManagementTemplateStepVersionModel>? ManagementTemplateStepVersions { get; set; }

    [JsonPropertyName("managementTemplateSteps")]
    public List<ManagementTemplateStepModel>? ManagementTemplateSteps { get; set; }

    [JsonPropertyName("managementTemplates")]
    public List<ManagementTemplateModel>? ManagementTemplates { get; set; }

    [JsonPropertyName("myRoles")]
    public List<MyRoleModel>? MyRoles { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantGroups")]
    public List<TenantGroupModel>? TenantGroups { get; set; }

    [JsonPropertyName("tenantTags")]
    public List<TenantTagModel>? TenantTags { get; set; }

    [JsonPropertyName("tenants")]
    public List<TenantModel>? Tenants { get; set; }

    [JsonPropertyName("tenantsCustomizedInformation")]
    public List<TenantCustomizedInformationModel>? TenantsCustomizedInformation { get; set; }

    [JsonPropertyName("tenantsDetailedInformation")]
    public List<TenantDetailedInformationModel>? TenantsDetailedInformation { get; set; }

    [JsonPropertyName("windowsDeviceMalwareStates")]
    public List<WindowsDeviceMalwareStateModel>? WindowsDeviceMalwareStates { get; set; }

    [JsonPropertyName("windowsProtectionStates")]
    public List<WindowsProtectionStateModel>? WindowsProtectionStates { get; set; }
}
