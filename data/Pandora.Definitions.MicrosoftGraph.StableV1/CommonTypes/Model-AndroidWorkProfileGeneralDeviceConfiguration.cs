// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AndroidWorkProfileGeneralDeviceConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBlockFingerprintUnlock")]
    public bool? PasswordBlockFingerprintUnlock { get; set; }

    [JsonPropertyName("passwordBlockTrustAgents")]
    public bool? PasswordBlockTrustAgents { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeScreenTimeout")]
    public int? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public AndroidWorkProfileRequiredPasswordTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("passwordSignInFailureCountBeforeFactoryReset")]
    public int? PasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("securityRequireVerifyApps")]
    public bool? SecurityRequireVerifyApps { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("workProfileBlockAddingAccounts")]
    public bool? WorkProfileBlockAddingAccounts { get; set; }

    [JsonPropertyName("workProfileBlockCamera")]
    public bool? WorkProfileBlockCamera { get; set; }

    [JsonPropertyName("workProfileBlockCrossProfileCallerId")]
    public bool? WorkProfileBlockCrossProfileCallerId { get; set; }

    [JsonPropertyName("workProfileBlockCrossProfileContactsSearch")]
    public bool? WorkProfileBlockCrossProfileContactsSearch { get; set; }

    [JsonPropertyName("workProfileBlockCrossProfileCopyPaste")]
    public bool? WorkProfileBlockCrossProfileCopyPaste { get; set; }

    [JsonPropertyName("workProfileBlockNotificationsWhileDeviceLocked")]
    public bool? WorkProfileBlockNotificationsWhileDeviceLocked { get; set; }

    [JsonPropertyName("workProfileBlockScreenCapture")]
    public bool? WorkProfileBlockScreenCapture { get; set; }

    [JsonPropertyName("workProfileBluetoothEnableContactSharing")]
    public bool? WorkProfileBluetoothEnableContactSharing { get; set; }

    [JsonPropertyName("workProfileDataSharingType")]
    public AndroidWorkProfileCrossProfileDataSharingTypeConstant? WorkProfileDataSharingType { get; set; }

    [JsonPropertyName("workProfileDefaultAppPermissionPolicy")]
    public AndroidWorkProfileDefaultAppPermissionPolicyTypeConstant? WorkProfileDefaultAppPermissionPolicy { get; set; }

    [JsonPropertyName("workProfilePasswordBlockFingerprintUnlock")]
    public bool? WorkProfilePasswordBlockFingerprintUnlock { get; set; }

    [JsonPropertyName("workProfilePasswordBlockTrustAgents")]
    public bool? WorkProfilePasswordBlockTrustAgents { get; set; }

    [JsonPropertyName("workProfilePasswordExpirationDays")]
    public int? WorkProfilePasswordExpirationDays { get; set; }

    [JsonPropertyName("workProfilePasswordMinLetterCharacters")]
    public int? WorkProfilePasswordMinLetterCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinLowerCaseCharacters")]
    public int? WorkProfilePasswordMinLowerCaseCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinNonLetterCharacters")]
    public int? WorkProfilePasswordMinNonLetterCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinNumericCharacters")]
    public int? WorkProfilePasswordMinNumericCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinSymbolCharacters")]
    public int? WorkProfilePasswordMinSymbolCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinUpperCaseCharacters")]
    public int? WorkProfilePasswordMinUpperCaseCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumLength")]
    public int? WorkProfilePasswordMinimumLength { get; set; }

    [JsonPropertyName("workProfilePasswordMinutesOfInactivityBeforeScreenTimeout")]
    public int? WorkProfilePasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("workProfilePasswordPreviousPasswordBlockCount")]
    public int? WorkProfilePasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("workProfilePasswordRequiredType")]
    public AndroidWorkProfileRequiredPasswordTypeConstant? WorkProfilePasswordRequiredType { get; set; }

    [JsonPropertyName("workProfilePasswordSignInFailureCountBeforeFactoryReset")]
    public int? WorkProfilePasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("workProfileRequirePassword")]
    public bool? WorkProfileRequirePassword { get; set; }
}
