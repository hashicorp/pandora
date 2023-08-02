// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosEasEmailProfileConfigurationModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("authenticationMethod")]
    public EasAuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("blockMovingMessagesToOtherEmailAccounts")]
    public bool? BlockMovingMessagesToOtherEmailAccounts { get; set; }

    [JsonPropertyName("blockSendingEmailFromThirdPartyApps")]
    public bool? BlockSendingEmailFromThirdPartyApps { get; set; }

    [JsonPropertyName("blockSyncingRecentlyUsedEmailAddresses")]
    public bool? BlockSyncingRecentlyUsedEmailAddresses { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customDomainName")]
    public string? CustomDomainName { get; set; }

    [JsonPropertyName("derivedCredentialSettings")]
    public DeviceManagementDerivedCredentialSettingsModel? DerivedCredentialSettings { get; set; }

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
    public EmailSyncDurationConstant? DurationOfEmailToSync { get; set; }

    [JsonPropertyName("easServices")]
    public EasServicesConstant? EasServices { get; set; }

    [JsonPropertyName("easServicesUserOverrideEnabled")]
    public bool? EasServicesUserOverrideEnabled { get; set; }

    [JsonPropertyName("emailAddressSource")]
    public UserEmailSourceConstant? EmailAddressSource { get; set; }

    [JsonPropertyName("encryptionCertificateType")]
    public EmailCertificateTypeConstant? EncryptionCertificateType { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityCertificate")]
    public IosCertificateProfileBaseModel? IdentityCertificate { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("perAppVPNProfileId")]
    public string? PerAppVPNProfileId { get; set; }

    [JsonPropertyName("requireSmime")]
    public bool? RequireSmime { get; set; }

    [JsonPropertyName("requireSsl")]
    public bool? RequireSsl { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("signingCertificateType")]
    public EmailCertificateTypeConstant? SigningCertificateType { get; set; }

    [JsonPropertyName("smimeEnablePerMessageSwitch")]
    public bool? SmimeEnablePerMessageSwitch { get; set; }

    [JsonPropertyName("smimeEncryptByDefaultEnabled")]
    public bool? SmimeEncryptByDefaultEnabled { get; set; }

    [JsonPropertyName("smimeEncryptByDefaultUserOverrideEnabled")]
    public bool? SmimeEncryptByDefaultUserOverrideEnabled { get; set; }

    [JsonPropertyName("smimeEncryptionCertificate")]
    public IosCertificateProfileModel? SmimeEncryptionCertificate { get; set; }

    [JsonPropertyName("smimeEncryptionCertificateUserOverrideEnabled")]
    public bool? SmimeEncryptionCertificateUserOverrideEnabled { get; set; }

    [JsonPropertyName("smimeSigningCertificate")]
    public IosCertificateProfileModel? SmimeSigningCertificate { get; set; }

    [JsonPropertyName("smimeSigningCertificateUserOverrideEnabled")]
    public bool? SmimeSigningCertificateUserOverrideEnabled { get; set; }

    [JsonPropertyName("smimeSigningEnabled")]
    public bool? SmimeSigningEnabled { get; set; }

    [JsonPropertyName("smimeSigningUserOverrideEnabled")]
    public bool? SmimeSigningUserOverrideEnabled { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("useOAuth")]
    public bool? UseOAuth { get; set; }

    [JsonPropertyName("userDomainNameSource")]
    public DomainNameSourceConstant? UserDomainNameSource { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("usernameAADSource")]
    public UsernameSourceConstant? UsernameAADSource { get; set; }

    [JsonPropertyName("usernameSource")]
    public UserEmailSourceConstant? UsernameSource { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
