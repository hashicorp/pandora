// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSGeneralDeviceConfigurationModel
{
    [JsonPropertyName("activationLockWhenSupervisedAllowed")]
    public bool? ActivationLockWhenSupervisedAllowed { get; set; }

    [JsonPropertyName("addingGameCenterFriendsBlocked")]
    public bool? AddingGameCenterFriendsBlocked { get; set; }

    [JsonPropertyName("airDropBlocked")]
    public bool? AirDropBlocked { get; set; }

    [JsonPropertyName("appleWatchBlockAutoUnlock")]
    public bool? AppleWatchBlockAutoUnlock { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("cameraBlocked")]
    public bool? CameraBlocked { get; set; }

    [JsonPropertyName("classroomAppBlockRemoteScreenObservation")]
    public bool? ClassroomAppBlockRemoteScreenObservation { get; set; }

    [JsonPropertyName("classroomAppForceUnpromptedScreenObservation")]
    public bool? ClassroomAppForceUnpromptedScreenObservation { get; set; }

    [JsonPropertyName("classroomForceAutomaticallyJoinClasses")]
    public bool? ClassroomForceAutomaticallyJoinClasses { get; set; }

    [JsonPropertyName("classroomForceRequestPermissionToLeaveClasses")]
    public bool? ClassroomForceRequestPermissionToLeaveClasses { get; set; }

    [JsonPropertyName("classroomForceUnpromptedAppAndDeviceLock")]
    public bool? ClassroomForceUnpromptedAppAndDeviceLock { get; set; }

    [JsonPropertyName("compliantAppListType")]
    public AppListTypeConstant? CompliantAppListType { get; set; }

    [JsonPropertyName("compliantAppsList")]
    public List<AppListItemModel>? CompliantAppsList { get; set; }

    [JsonPropertyName("contentCachingBlocked")]
    public bool? ContentCachingBlocked { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("definitionLookupBlocked")]
    public bool? DefinitionLookupBlocked { get; set; }

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

    [JsonPropertyName("emailInDomainSuffixes")]
    public List<string>? EmailInDomainSuffixes { get; set; }

    [JsonPropertyName("eraseContentAndSettingsBlocked")]
    public bool? EraseContentAndSettingsBlocked { get; set; }

    [JsonPropertyName("gameCenterBlocked")]
    public bool? GameCenterBlocked { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("iCloudBlockActivityContinuation")]
    public bool? ICloudBlockActivityContinuation { get; set; }

    [JsonPropertyName("iCloudBlockAddressBook")]
    public bool? ICloudBlockAddressBook { get; set; }

    [JsonPropertyName("iCloudBlockBookmarks")]
    public bool? ICloudBlockBookmarks { get; set; }

    [JsonPropertyName("iCloudBlockCalendar")]
    public bool? ICloudBlockCalendar { get; set; }

    [JsonPropertyName("iCloudBlockDocumentSync")]
    public bool? ICloudBlockDocumentSync { get; set; }

    [JsonPropertyName("iCloudBlockMail")]
    public bool? ICloudBlockMail { get; set; }

    [JsonPropertyName("iCloudBlockNotes")]
    public bool? ICloudBlockNotes { get; set; }

    [JsonPropertyName("iCloudBlockPhotoLibrary")]
    public bool? ICloudBlockPhotoLibrary { get; set; }

    [JsonPropertyName("iCloudBlockReminders")]
    public bool? ICloudBlockReminders { get; set; }

    [JsonPropertyName("iCloudDesktopAndDocumentsBlocked")]
    public bool? ICloudDesktopAndDocumentsBlocked { get; set; }

    [JsonPropertyName("iCloudPrivateRelayBlocked")]
    public bool? ICloudPrivateRelayBlocked { get; set; }

    [JsonPropertyName("iTunesBlockFileSharing")]
    public bool? ITunesBlockFileSharing { get; set; }

    [JsonPropertyName("iTunesBlockMusicService")]
    public bool? ITunesBlockMusicService { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("keyboardBlockDictation")]
    public bool? KeyboardBlockDictation { get; set; }

    [JsonPropertyName("keychainBlockCloudSync")]
    public bool? KeychainBlockCloudSync { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("multiplayerGamingBlocked")]
    public bool? MultiplayerGamingBlocked { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBlockAirDropSharing")]
    public bool? PasswordBlockAirDropSharing { get; set; }

    [JsonPropertyName("passwordBlockAutoFill")]
    public bool? PasswordBlockAutoFill { get; set; }

    [JsonPropertyName("passwordBlockFingerprintUnlock")]
    public bool? PasswordBlockFingerprintUnlock { get; set; }

    [JsonPropertyName("passwordBlockModification")]
    public bool? PasswordBlockModification { get; set; }

    [JsonPropertyName("passwordBlockProximityRequests")]
    public bool? PasswordBlockProximityRequests { get; set; }

    [JsonPropertyName("passwordBlockSimple")]
    public bool? PasswordBlockSimple { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMaximumAttemptCount")]
    public int? PasswordMaximumAttemptCount { get; set; }

    [JsonPropertyName("passwordMinimumCharacterSetCount")]
    public int? PasswordMinimumCharacterSetCount { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeLock")]
    public int? PasswordMinutesOfInactivityBeforeLock { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeScreenTimeout")]
    public int? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("passwordMinutesUntilFailedLoginReset")]
    public int? PasswordMinutesUntilFailedLoginReset { get; set; }

    [JsonPropertyName("passwordPreviousPasswordBlockCount")]
    public int? PasswordPreviousPasswordBlockCount { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public RequiredPasswordTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("privacyAccessControls")]
    public List<MacOSPrivacyAccessControlItemModel>? PrivacyAccessControls { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("safariBlockAutofill")]
    public bool? SafariBlockAutofill { get; set; }

    [JsonPropertyName("screenCaptureBlocked")]
    public bool? ScreenCaptureBlocked { get; set; }

    [JsonPropertyName("softwareUpdateMajorOSDeferredInstallDelayInDays")]
    public int? SoftwareUpdateMajorOSDeferredInstallDelayInDays { get; set; }

    [JsonPropertyName("softwareUpdateMinorOSDeferredInstallDelayInDays")]
    public int? SoftwareUpdateMinorOSDeferredInstallDelayInDays { get; set; }

    [JsonPropertyName("softwareUpdateNonOSDeferredInstallDelayInDays")]
    public int? SoftwareUpdateNonOSDeferredInstallDelayInDays { get; set; }

    [JsonPropertyName("softwareUpdatesEnforcedDelayInDays")]
    public int? SoftwareUpdatesEnforcedDelayInDays { get; set; }

    [JsonPropertyName("spotlightBlockInternetResults")]
    public bool? SpotlightBlockInternetResults { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("touchIdTimeoutInHours")]
    public int? TouchIdTimeoutInHours { get; set; }

    [JsonPropertyName("updateDelayPolicy")]
    public MacOSSoftwareUpdateDelayPolicyConstant? UpdateDelayPolicy { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("wallpaperModificationBlocked")]
    public bool? WallpaperModificationBlocked { get; set; }
}
