// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSEndpointProtectionConfigurationModel
{
    [JsonPropertyName("advancedThreatProtectionAutomaticSampleSubmission")]
    public EnablementConstant? AdvancedThreatProtectionAutomaticSampleSubmission { get; set; }

    [JsonPropertyName("advancedThreatProtectionCloudDelivered")]
    public EnablementConstant? AdvancedThreatProtectionCloudDelivered { get; set; }

    [JsonPropertyName("advancedThreatProtectionDiagnosticDataCollection")]
    public EnablementConstant? AdvancedThreatProtectionDiagnosticDataCollection { get; set; }

    [JsonPropertyName("advancedThreatProtectionExcludedExtensions")]
    public List<string>? AdvancedThreatProtectionExcludedExtensions { get; set; }

    [JsonPropertyName("advancedThreatProtectionExcludedFiles")]
    public List<string>? AdvancedThreatProtectionExcludedFiles { get; set; }

    [JsonPropertyName("advancedThreatProtectionExcludedFolders")]
    public List<string>? AdvancedThreatProtectionExcludedFolders { get; set; }

    [JsonPropertyName("advancedThreatProtectionExcludedProcesses")]
    public List<string>? AdvancedThreatProtectionExcludedProcesses { get; set; }

    [JsonPropertyName("advancedThreatProtectionRealTime")]
    public EnablementConstant? AdvancedThreatProtectionRealTime { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

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

    [JsonPropertyName("fileVaultAllowDeferralUntilSignOut")]
    public bool? FileVaultAllowDeferralUntilSignOut { get; set; }

    [JsonPropertyName("fileVaultDisablePromptAtSignOut")]
    public bool? FileVaultDisablePromptAtSignOut { get; set; }

    [JsonPropertyName("fileVaultEnabled")]
    public bool? FileVaultEnabled { get; set; }

    [JsonPropertyName("fileVaultHidePersonalRecoveryKey")]
    public bool? FileVaultHidePersonalRecoveryKey { get; set; }

    [JsonPropertyName("fileVaultInstitutionalRecoveryKeyCertificate")]
    public string? FileVaultInstitutionalRecoveryKeyCertificate { get; set; }

    [JsonPropertyName("fileVaultInstitutionalRecoveryKeyCertificateFileName")]
    public string? FileVaultInstitutionalRecoveryKeyCertificateFileName { get; set; }

    [JsonPropertyName("fileVaultNumberOfTimesUserCanIgnore")]
    public int? FileVaultNumberOfTimesUserCanIgnore { get; set; }

    [JsonPropertyName("fileVaultPersonalRecoveryKeyHelpMessage")]
    public string? FileVaultPersonalRecoveryKeyHelpMessage { get; set; }

    [JsonPropertyName("fileVaultPersonalRecoveryKeyRotationInMonths")]
    public int? FileVaultPersonalRecoveryKeyRotationInMonths { get; set; }

    [JsonPropertyName("fileVaultSelectedRecoveryKeyTypes")]
    public MacOSFileVaultRecoveryKeyTypesConstant? FileVaultSelectedRecoveryKeyTypes { get; set; }

    [JsonPropertyName("firewallApplications")]
    public List<MacOSFirewallApplicationModel>? FirewallApplications { get; set; }

    [JsonPropertyName("firewallBlockAllIncoming")]
    public bool? FirewallBlockAllIncoming { get; set; }

    [JsonPropertyName("firewallEnableStealthMode")]
    public bool? FirewallEnableStealthMode { get; set; }

    [JsonPropertyName("firewallEnabled")]
    public bool? FirewallEnabled { get; set; }

    [JsonPropertyName("gatekeeperAllowedAppSource")]
    public MacOSGatekeeperAppSourcesConstant? GatekeeperAllowedAppSource { get; set; }

    [JsonPropertyName("gatekeeperBlockOverride")]
    public bool? GatekeeperBlockOverride { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

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
}
