// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSDeviceFeaturesConfigurationModel
{
    [JsonPropertyName("adminShowHostInfo")]
    public bool? AdminShowHostInfo { get; set; }

    [JsonPropertyName("airPrintDestinations")]
    public List<AirPrintDestinationModel>? AirPrintDestinations { get; set; }

    [JsonPropertyName("appAssociatedDomains")]
    public List<MacOSAssociatedDomainsItemModel>? AppAssociatedDomains { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("associatedDomains")]
    public List<KeyValuePairModel>? AssociatedDomains { get; set; }

    [JsonPropertyName("authorizedUsersListHidden")]
    public bool? AuthorizedUsersListHidden { get; set; }

    [JsonPropertyName("authorizedUsersListHideAdminUsers")]
    public bool? AuthorizedUsersListHideAdminUsers { get; set; }

    [JsonPropertyName("authorizedUsersListHideLocalUsers")]
    public bool? AuthorizedUsersListHideLocalUsers { get; set; }

    [JsonPropertyName("authorizedUsersListHideMobileAccounts")]
    public bool? AuthorizedUsersListHideMobileAccounts { get; set; }

    [JsonPropertyName("authorizedUsersListIncludeNetworkUsers")]
    public bool? AuthorizedUsersListIncludeNetworkUsers { get; set; }

    [JsonPropertyName("authorizedUsersListShowOtherManagedUsers")]
    public bool? AuthorizedUsersListShowOtherManagedUsers { get; set; }

    [JsonPropertyName("autoLaunchItems")]
    public List<MacOSLaunchItemModel>? AutoLaunchItems { get; set; }

    [JsonPropertyName("consoleAccessDisabled")]
    public bool? ConsoleAccessDisabled { get; set; }

    [JsonPropertyName("contentCachingBlockDeletion")]
    public bool? ContentCachingBlockDeletion { get; set; }

    [JsonPropertyName("contentCachingClientListenRanges")]
    public List<IpRangeModel>? ContentCachingClientListenRanges { get; set; }

    [JsonPropertyName("contentCachingClientPolicy")]
    public MacOSContentCachingClientPolicyConstant? ContentCachingClientPolicy { get; set; }

    [JsonPropertyName("contentCachingDataPath")]
    public string? ContentCachingDataPath { get; set; }

    [JsonPropertyName("contentCachingDisableConnectionSharing")]
    public bool? ContentCachingDisableConnectionSharing { get; set; }

    [JsonPropertyName("contentCachingEnabled")]
    public bool? ContentCachingEnabled { get; set; }

    [JsonPropertyName("contentCachingForceConnectionSharing")]
    public bool? ContentCachingForceConnectionSharing { get; set; }

    [JsonPropertyName("contentCachingKeepAwake")]
    public bool? ContentCachingKeepAwake { get; set; }

    [JsonPropertyName("contentCachingLogClientIdentities")]
    public bool? ContentCachingLogClientIdentities { get; set; }

    [JsonPropertyName("contentCachingMaxSizeBytes")]
    public long? ContentCachingMaxSizeBytes { get; set; }

    [JsonPropertyName("contentCachingParentSelectionPolicy")]
    public MacOSContentCachingParentSelectionPolicyConstant? ContentCachingParentSelectionPolicy { get; set; }

    [JsonPropertyName("contentCachingParents")]
    public List<string>? ContentCachingParents { get; set; }

    [JsonPropertyName("contentCachingPeerFilterRanges")]
    public List<IpRangeModel>? ContentCachingPeerFilterRanges { get; set; }

    [JsonPropertyName("contentCachingPeerListenRanges")]
    public List<IpRangeModel>? ContentCachingPeerListenRanges { get; set; }

    [JsonPropertyName("contentCachingPeerPolicy")]
    public MacOSContentCachingPeerPolicyConstant? ContentCachingPeerPolicy { get; set; }

    [JsonPropertyName("contentCachingPort")]
    public int? ContentCachingPort { get; set; }

    [JsonPropertyName("contentCachingPublicRanges")]
    public List<IpRangeModel>? ContentCachingPublicRanges { get; set; }

    [JsonPropertyName("contentCachingShowAlerts")]
    public bool? ContentCachingShowAlerts { get; set; }

    [JsonPropertyName("contentCachingType")]
    public MacOSContentCachingTypeConstant? ContentCachingType { get; set; }

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

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("logOutDisabledWhileLoggedIn")]
    public bool? LogOutDisabledWhileLoggedIn { get; set; }

    [JsonPropertyName("loginWindowText")]
    public string? LoginWindowText { get; set; }

    [JsonPropertyName("macOSSingleSignOnExtension")]
    public MacOSSingleSignOnExtensionModel? MacOSSingleSignOnExtension { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("powerOffDisabledWhileLoggedIn")]
    public bool? PowerOffDisabledWhileLoggedIn { get; set; }

    [JsonPropertyName("restartDisabled")]
    public bool? RestartDisabled { get; set; }

    [JsonPropertyName("restartDisabledWhileLoggedIn")]
    public bool? RestartDisabledWhileLoggedIn { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("screenLockDisableImmediate")]
    public bool? ScreenLockDisableImmediate { get; set; }

    [JsonPropertyName("shutDownDisabled")]
    public bool? ShutDownDisabled { get; set; }

    [JsonPropertyName("shutDownDisabledWhileLoggedIn")]
    public bool? ShutDownDisabledWhileLoggedIn { get; set; }

    [JsonPropertyName("singleSignOnExtension")]
    public SingleSignOnExtensionModel? SingleSignOnExtension { get; set; }

    [JsonPropertyName("singleSignOnExtensionPkinitCertificate")]
    public MacOSCertificateProfileBaseModel? SingleSignOnExtensionPkinitCertificate { get; set; }

    [JsonPropertyName("sleepDisabled")]
    public bool? SleepDisabled { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
