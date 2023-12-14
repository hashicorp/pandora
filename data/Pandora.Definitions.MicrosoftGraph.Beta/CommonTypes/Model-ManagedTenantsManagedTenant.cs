// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagedTenantModel
{
    [JsonPropertyName("aggregatedPolicyCompliances")]
    public List<ManagedTenantsAggregatedPolicyComplianceModel>? AggregatedPolicyCompliances { get; set; }

    [JsonPropertyName("appPerformances")]
    public List<ManagedTenantsAppPerformanceModel>? AppPerformances { get; set; }

    [JsonPropertyName("auditEvents")]
    public List<ManagedTenantsAuditEventModel>? AuditEvents { get; set; }

    [JsonPropertyName("cloudPcConnections")]
    public List<ManagedTenantsCloudPCConnectionModel>? CloudPCConnections { get; set; }

    [JsonPropertyName("cloudPcDevices")]
    public List<ManagedTenantsCloudPCDeviceModel>? CloudPCDevices { get; set; }

    [JsonPropertyName("cloudPcsOverview")]
    public List<ManagedTenantsCloudPCOverviewModel>? CloudPCsOverview { get; set; }

    [JsonPropertyName("conditionalAccessPolicyCoverages")]
    public List<ManagedTenantsConditionalAccessPolicyCoverageModel>? ConditionalAccessPolicyCoverages { get; set; }

    [JsonPropertyName("credentialUserRegistrationsSummaries")]
    public List<ManagedTenantsCredentialUserRegistrationsSummaryModel>? CredentialUserRegistrationsSummaries { get; set; }

    [JsonPropertyName("deviceAppPerformances")]
    public List<ManagedTenantsDeviceAppPerformanceModel>? DeviceAppPerformances { get; set; }

    [JsonPropertyName("deviceCompliancePolicySettingStateSummaries")]
    public List<ManagedTenantsDeviceCompliancePolicySettingStateSummaryModel>? DeviceCompliancePolicySettingStateSummaries { get; set; }

    [JsonPropertyName("deviceHealthStatuses")]
    public List<ManagedTenantsDeviceHealthStatusModel>? DeviceHealthStatuses { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceComplianceTrends")]
    public List<ManagedTenantsManagedDeviceComplianceTrendModel>? ManagedDeviceComplianceTrends { get; set; }

    [JsonPropertyName("managedDeviceCompliances")]
    public List<ManagedTenantsManagedDeviceComplianceModel>? ManagedDeviceCompliances { get; set; }

    [JsonPropertyName("managedTenantAlertLogs")]
    public List<ManagedTenantsManagedTenantAlertLogModel>? ManagedTenantAlertLogs { get; set; }

    [JsonPropertyName("managedTenantAlertRuleDefinitions")]
    public List<ManagedTenantsManagedTenantAlertRuleDefinitionModel>? ManagedTenantAlertRuleDefinitions { get; set; }

    [JsonPropertyName("managedTenantAlertRules")]
    public List<ManagedTenantsManagedTenantAlertRuleModel>? ManagedTenantAlertRules { get; set; }

    [JsonPropertyName("managedTenantAlerts")]
    public List<ManagedTenantsManagedTenantAlertModel>? ManagedTenantAlerts { get; set; }

    [JsonPropertyName("managedTenantApiNotifications")]
    public List<ManagedTenantsManagedTenantApiNotificationModel>? ManagedTenantApiNotifications { get; set; }

    [JsonPropertyName("managedTenantEmailNotifications")]
    public List<ManagedTenantsManagedTenantEmailNotificationModel>? ManagedTenantEmailNotifications { get; set; }

    [JsonPropertyName("managedTenantTicketingEndpoints")]
    public List<ManagedTenantsManagedTenantTicketingEndpointModel>? ManagedTenantTicketingEndpoints { get; set; }

    [JsonPropertyName("managementActionTenantDeploymentStatuses")]
    public List<ManagedTenantsManagementActionTenantDeploymentStatusModel>? ManagementActionTenantDeploymentStatuses { get; set; }

    [JsonPropertyName("managementActions")]
    public List<ManagedTenantsManagementActionModel>? ManagementActions { get; set; }

    [JsonPropertyName("managementIntents")]
    public List<ManagedTenantsManagementIntentModel>? ManagementIntents { get; set; }

    [JsonPropertyName("managementTemplateCollectionTenantSummaries")]
    public List<ManagedTenantsManagementTemplateCollectionTenantSummaryModel>? ManagementTemplateCollectionTenantSummaries { get; set; }

    [JsonPropertyName("managementTemplateCollections")]
    public List<ManagedTenantsManagementTemplateCollectionModel>? ManagementTemplateCollections { get; set; }

    [JsonPropertyName("managementTemplateStepTenantSummaries")]
    public List<ManagedTenantsManagementTemplateStepTenantSummaryModel>? ManagementTemplateStepTenantSummaries { get; set; }

    [JsonPropertyName("managementTemplateStepVersions")]
    public List<ManagedTenantsManagementTemplateStepVersionModel>? ManagementTemplateStepVersions { get; set; }

    [JsonPropertyName("managementTemplateSteps")]
    public List<ManagedTenantsManagementTemplateStepModel>? ManagementTemplateSteps { get; set; }

    [JsonPropertyName("managementTemplates")]
    public List<ManagedTenantsManagementTemplateModel>? ManagementTemplates { get; set; }

    [JsonPropertyName("myRoles")]
    public List<ManagedTenantsMyRoleModel>? MyRoles { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantGroups")]
    public List<ManagedTenantsTenantGroupModel>? TenantGroups { get; set; }

    [JsonPropertyName("tenantTags")]
    public List<ManagedTenantsTenantTagModel>? TenantTags { get; set; }

    [JsonPropertyName("tenants")]
    public List<ManagedTenantsTenantModel>? Tenants { get; set; }

    [JsonPropertyName("tenantsCustomizedInformation")]
    public List<ManagedTenantsTenantCustomizedInformationModel>? TenantsCustomizedInformation { get; set; }

    [JsonPropertyName("tenantsDetailedInformation")]
    public List<ManagedTenantsTenantDetailedInformationModel>? TenantsDetailedInformation { get; set; }

    [JsonPropertyName("windowsDeviceMalwareStates")]
    public List<ManagedTenantsWindowsDeviceMalwareStateModel>? WindowsDeviceMalwareStates { get; set; }

    [JsonPropertyName("windowsProtectionStates")]
    public List<ManagedTenantsWindowsProtectionStateModel>? WindowsProtectionStates { get; set; }
}
