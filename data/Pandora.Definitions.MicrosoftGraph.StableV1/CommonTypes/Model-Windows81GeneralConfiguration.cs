// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class Windows81GeneralConfigurationModel
{
    [JsonPropertyName("accountsBlockAddingNonMicrosoftAccountEmail")]
    public bool? AccountsBlockAddingNonMicrosoftAccountEmail { get; set; }

    [JsonPropertyName("applyOnlyToWindows81")]
    public bool? ApplyOnlyToWindows81 { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("browserBlockAutofill")]
    public bool? BrowserBlockAutofill { get; set; }

    [JsonPropertyName("browserBlockAutomaticDetectionOfIntranetSites")]
    public bool? BrowserBlockAutomaticDetectionOfIntranetSites { get; set; }

    [JsonPropertyName("browserBlockEnterpriseModeAccess")]
    public bool? BrowserBlockEnterpriseModeAccess { get; set; }

    [JsonPropertyName("browserBlockJavaScript")]
    public bool? BrowserBlockJavaScript { get; set; }

    [JsonPropertyName("browserBlockPlugins")]
    public bool? BrowserBlockPlugins { get; set; }

    [JsonPropertyName("browserBlockPopups")]
    public bool? BrowserBlockPopups { get; set; }

    [JsonPropertyName("browserBlockSendingDoNotTrackHeader")]
    public bool? BrowserBlockSendingDoNotTrackHeader { get; set; }

    [JsonPropertyName("browserBlockSingleWordEntryOnIntranetSites")]
    public bool? BrowserBlockSingleWordEntryOnIntranetSites { get; set; }

    [JsonPropertyName("browserEnterpriseModeSiteListLocation")]
    public string? BrowserEnterpriseModeSiteListLocation { get; set; }

    [JsonPropertyName("browserInternetSecurityLevel")]
    public InternetSiteSecurityLevelConstant? BrowserInternetSecurityLevel { get; set; }

    [JsonPropertyName("browserIntranetSecurityLevel")]
    public SiteSecurityLevelConstant? BrowserIntranetSecurityLevel { get; set; }

    [JsonPropertyName("browserLoggingReportLocation")]
    public string? BrowserLoggingReportLocation { get; set; }

    [JsonPropertyName("browserRequireFirewall")]
    public bool? BrowserRequireFirewall { get; set; }

    [JsonPropertyName("browserRequireFraudWarning")]
    public bool? BrowserRequireFraudWarning { get; set; }

    [JsonPropertyName("browserRequireHighSecurityForRestrictedSites")]
    public bool? BrowserRequireHighSecurityForRestrictedSites { get; set; }

    [JsonPropertyName("browserRequireSmartScreen")]
    public bool? BrowserRequireSmartScreen { get; set; }

    [JsonPropertyName("browserTrustedSitesSecurityLevel")]
    public SiteSecurityLevelConstant? BrowserTrustedSitesSecurityLevel { get; set; }

    [JsonPropertyName("cellularBlockDataRoaming")]
    public bool? CellularBlockDataRoaming { get; set; }

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

    [JsonPropertyName("diagnosticsBlockDataSubmission")]
    public bool? DiagnosticsBlockDataSubmission { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBlockPicturePasswordAndPin")]
    public bool? PasswordBlockPicturePasswordAndPin { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumCharacterSetCount")]
    public int? PasswordMinimumCharacterSetCount { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeScreenTimeout")]
    public int? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public RequiredPasswordTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("passwordSignInFailureCountBeforeFactoryReset")]
    public int? PasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("storageRequireDeviceEncryption")]
    public bool? StorageRequireDeviceEncryption { get; set; }

    [JsonPropertyName("updatesRequireAutomaticUpdates")]
    public bool? UpdatesRequireAutomaticUpdates { get; set; }

    [JsonPropertyName("userAccountControlSettings")]
    public WindowsUserAccountControlSettingsConstant? UserAccountControlSettings { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("workFoldersUrl")]
    public string? WorkFoldersUrl { get; set; }
}
