// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidEasEmailProfileConfigurationModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("authenticationMethod")]
    public AndroidEasEmailProfileConfigurationAuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customDomainName")]
    public string? CustomDomainName { get; set; }

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

    [JsonPropertyName("durationOfEmailToSync")]
    public AndroidEasEmailProfileConfigurationDurationOfEmailToSyncConstant? DurationOfEmailToSync { get; set; }

    [JsonPropertyName("emailAddressSource")]
    public AndroidEasEmailProfileConfigurationEmailAddressSourceConstant? EmailAddressSource { get; set; }

    [JsonPropertyName("emailSyncSchedule")]
    public AndroidEasEmailProfileConfigurationEmailSyncScheduleConstant? EmailSyncSchedule { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityCertificate")]
    public AndroidCertificateProfileBaseModel? IdentityCertificate { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requireSmime")]
    public bool? RequireSmime { get; set; }

    [JsonPropertyName("requireSsl")]
    public bool? RequireSsl { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("smimeSigningCertificate")]
    public AndroidCertificateProfileBaseModel? SmimeSigningCertificate { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("syncCalendar")]
    public bool? SyncCalendar { get; set; }

    [JsonPropertyName("syncContacts")]
    public bool? SyncContacts { get; set; }

    [JsonPropertyName("syncNotes")]
    public bool? SyncNotes { get; set; }

    [JsonPropertyName("syncTasks")]
    public bool? SyncTasks { get; set; }

    [JsonPropertyName("userDomainNameSource")]
    public AndroidEasEmailProfileConfigurationUserDomainNameSourceConstant? UserDomainNameSource { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("usernameSource")]
    public AndroidEasEmailProfileConfigurationUsernameSourceConstant? UsernameSource { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
