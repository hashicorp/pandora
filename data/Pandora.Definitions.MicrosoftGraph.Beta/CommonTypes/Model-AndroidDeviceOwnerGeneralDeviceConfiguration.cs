// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidDeviceOwnerGeneralDeviceConfigurationModel
{
    [JsonPropertyName("accountsBlockModification")]
    public bool? AccountsBlockModification { get; set; }

    [JsonPropertyName("appsAllowInstallFromUnknownSources")]
    public bool? AppsAllowInstallFromUnknownSources { get; set; }

    [JsonPropertyName("appsAutoUpdatePolicy")]
    public AndroidDeviceOwnerAppAutoUpdatePolicyTypeConstant? AppsAutoUpdatePolicy { get; set; }

    [JsonPropertyName("appsDefaultPermissionPolicy")]
    public AndroidDeviceOwnerDefaultAppPermissionPolicyTypeConstant? AppsDefaultPermissionPolicy { get; set; }

    [JsonPropertyName("appsRecommendSkippingFirstUseHints")]
    public bool? AppsRecommendSkippingFirstUseHints { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("azureAdSharedDeviceDataClearApps")]
    public List<AppListItemModel>? AzureAdSharedDeviceDataClearApps { get; set; }

    [JsonPropertyName("bluetoothBlockConfiguration")]
    public bool? BluetoothBlockConfiguration { get; set; }

    [JsonPropertyName("bluetoothBlockContactSharing")]
    public bool? BluetoothBlockContactSharing { get; set; }

    [JsonPropertyName("cameraBlocked")]
    public bool? CameraBlocked { get; set; }

    [JsonPropertyName("cellularBlockWiFiTethering")]
    public bool? CellularBlockWiFiTethering { get; set; }

    [JsonPropertyName("certificateCredentialConfigurationDisabled")]
    public bool? CertificateCredentialConfigurationDisabled { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("crossProfilePoliciesAllowCopyPaste")]
    public bool? CrossProfilePoliciesAllowCopyPaste { get; set; }

    [JsonPropertyName("crossProfilePoliciesAllowDataSharing")]
    public AndroidDeviceOwnerCrossProfileDataSharingConstant? CrossProfilePoliciesAllowDataSharing { get; set; }

    [JsonPropertyName("crossProfilePoliciesShowWorkContactsInPersonalProfile")]
    public bool? CrossProfilePoliciesShowWorkContactsInPersonalProfile { get; set; }

    [JsonPropertyName("dataRoamingBlocked")]
    public bool? DataRoamingBlocked { get; set; }

    [JsonPropertyName("dateTimeConfigurationBlocked")]
    public bool? DateTimeConfigurationBlocked { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detailedHelpText")]
    public AndroidDeviceOwnerUserFacingMessageModel? DetailedHelpText { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleDeviceMode")]
    public DeviceManagementApplicabilityRuleDeviceModeModel? DeviceManagementApplicabilityRuleDeviceMode { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleOsEdition")]
    public DeviceManagementApplicabilityRuleOsEditionModel? DeviceManagementApplicabilityRuleOsEdition { get; set; }

    [JsonPropertyName("deviceManagementApplicabilityRuleOsVersion")]
    public DeviceManagementApplicabilityRuleOsVersionModel? DeviceManagementApplicabilityRuleOsVersion { get; set; }

    [JsonPropertyName("deviceOwnerLockScreenMessage")]
    public AndroidDeviceOwnerUserFacingMessageModel? DeviceOwnerLockScreenMessage { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enrollmentProfile")]
    public AndroidDeviceOwnerEnrollmentProfileTypeConstant? EnrollmentProfile { get; set; }

    [JsonPropertyName("factoryResetBlocked")]
    public bool? FactoryResetBlocked { get; set; }

    [JsonPropertyName("factoryResetDeviceAdministratorEmails")]
    public List<string>? FactoryResetDeviceAdministratorEmails { get; set; }

    [JsonPropertyName("globalProxy")]
    public AndroidDeviceOwnerGlobalProxyModel? GlobalProxy { get; set; }

    [JsonPropertyName("googleAccountsBlocked")]
    public bool? GoogleAccountsBlocked { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("kioskCustomizationDeviceSettingsBlocked")]
    public bool? KioskCustomizationDeviceSettingsBlocked { get; set; }

    [JsonPropertyName("kioskCustomizationPowerButtonActionsBlocked")]
    public bool? KioskCustomizationPowerButtonActionsBlocked { get; set; }

    [JsonPropertyName("kioskCustomizationStatusBar")]
    public AndroidDeviceOwnerKioskCustomizationStatusBarConstant? KioskCustomizationStatusBar { get; set; }

    [JsonPropertyName("kioskCustomizationSystemErrorWarnings")]
    public bool? KioskCustomizationSystemErrorWarnings { get; set; }

    [JsonPropertyName("kioskCustomizationSystemNavigation")]
    public AndroidDeviceOwnerKioskCustomizationSystemNavigationConstant? KioskCustomizationSystemNavigation { get; set; }

    [JsonPropertyName("kioskModeAppOrderEnabled")]
    public bool? KioskModeAppOrderEnabled { get; set; }

    [JsonPropertyName("kioskModeAppPositions")]
    public List<AndroidDeviceOwnerKioskModeAppPositionItemModel>? KioskModeAppPositions { get; set; }

    [JsonPropertyName("kioskModeApps")]
    public List<AppListItemModel>? KioskModeApps { get; set; }

    [JsonPropertyName("kioskModeAppsInFolderOrderedByName")]
    public bool? KioskModeAppsInFolderOrderedByName { get; set; }

    [JsonPropertyName("kioskModeBluetoothConfigurationEnabled")]
    public bool? KioskModeBluetoothConfigurationEnabled { get; set; }

    [JsonPropertyName("kioskModeDebugMenuEasyAccessEnabled")]
    public bool? KioskModeDebugMenuEasyAccessEnabled { get; set; }

    [JsonPropertyName("kioskModeExitCode")]
    public string? KioskModeExitCode { get; set; }

    [JsonPropertyName("kioskModeFlashlightConfigurationEnabled")]
    public bool? KioskModeFlashlightConfigurationEnabled { get; set; }

    [JsonPropertyName("kioskModeFolderIcon")]
    public AndroidDeviceOwnerKioskModeFolderIconConstant? KioskModeFolderIcon { get; set; }

    [JsonPropertyName("kioskModeGridHeight")]
    public int? KioskModeGridHeight { get; set; }

    [JsonPropertyName("kioskModeGridWidth")]
    public int? KioskModeGridWidth { get; set; }

    [JsonPropertyName("kioskModeIconSize")]
    public AndroidDeviceOwnerKioskModeIconSizeConstant? KioskModeIconSize { get; set; }

    [JsonPropertyName("kioskModeLockHomeScreen")]
    public bool? KioskModeLockHomeScreen { get; set; }

    [JsonPropertyName("kioskModeManagedFolders")]
    public List<AndroidDeviceOwnerKioskModeManagedFolderModel>? KioskModeManagedFolders { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenAutoSignout")]
    public bool? KioskModeManagedHomeScreenAutoSignout { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenInactiveSignOutDelayInSeconds")]
    public int? KioskModeManagedHomeScreenInactiveSignOutDelayInSeconds { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenInactiveSignOutNoticeInSeconds")]
    public int? KioskModeManagedHomeScreenInactiveSignOutNoticeInSeconds { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenPinComplexity")]
    public KioskModeManagedHomeScreenPinComplexityConstant? KioskModeManagedHomeScreenPinComplexity { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenPinRequired")]
    public bool? KioskModeManagedHomeScreenPinRequired { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenPinRequiredToResume")]
    public bool? KioskModeManagedHomeScreenPinRequiredToResume { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenSignInBackground")]
    public string? KioskModeManagedHomeScreenSignInBackground { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenSignInBrandingLogo")]
    public string? KioskModeManagedHomeScreenSignInBrandingLogo { get; set; }

    [JsonPropertyName("kioskModeManagedHomeScreenSignInEnabled")]
    public bool? KioskModeManagedHomeScreenSignInEnabled { get; set; }

    [JsonPropertyName("kioskModeManagedSettingsEntryDisabled")]
    public bool? KioskModeManagedSettingsEntryDisabled { get; set; }

    [JsonPropertyName("kioskModeMediaVolumeConfigurationEnabled")]
    public bool? KioskModeMediaVolumeConfigurationEnabled { get; set; }

    [JsonPropertyName("kioskModeScreenOrientation")]
    public AndroidDeviceOwnerKioskModeScreenOrientationConstant? KioskModeScreenOrientation { get; set; }

    [JsonPropertyName("kioskModeScreenSaverConfigurationEnabled")]
    public bool? KioskModeScreenSaverConfigurationEnabled { get; set; }

    [JsonPropertyName("kioskModeScreenSaverDetectMediaDisabled")]
    public bool? KioskModeScreenSaverDetectMediaDisabled { get; set; }

    [JsonPropertyName("kioskModeScreenSaverDisplayTimeInSeconds")]
    public int? KioskModeScreenSaverDisplayTimeInSeconds { get; set; }

    [JsonPropertyName("kioskModeScreenSaverImageUrl")]
    public string? KioskModeScreenSaverImageUrl { get; set; }

    [JsonPropertyName("kioskModeScreenSaverStartDelayInSeconds")]
    public int? KioskModeScreenSaverStartDelayInSeconds { get; set; }

    [JsonPropertyName("kioskModeShowAppNotificationBadge")]
    public bool? KioskModeShowAppNotificationBadge { get; set; }

    [JsonPropertyName("kioskModeShowDeviceInfo")]
    public bool? KioskModeShowDeviceInfo { get; set; }

    [JsonPropertyName("kioskModeUseManagedHomeScreenApp")]
    public KioskModeTypeConstant? KioskModeUseManagedHomeScreenApp { get; set; }

    [JsonPropertyName("kioskModeVirtualHomeButtonEnabled")]
    public bool? KioskModeVirtualHomeButtonEnabled { get; set; }

    [JsonPropertyName("kioskModeVirtualHomeButtonType")]
    public AndroidDeviceOwnerVirtualHomeButtonTypeConstant? KioskModeVirtualHomeButtonType { get; set; }

    [JsonPropertyName("kioskModeWallpaperUrl")]
    public string? KioskModeWallpaperUrl { get; set; }

    [JsonPropertyName("kioskModeWiFiConfigurationEnabled")]
    public bool? KioskModeWiFiConfigurationEnabled { get; set; }

    [JsonPropertyName("kioskModeWifiAllowedSsids")]
    public List<string>? KioskModeWifiAllowedSsids { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("locateDeviceLostModeEnabled")]
    public bool? LocateDeviceLostModeEnabled { get; set; }

    [JsonPropertyName("locateDeviceUserlessDisabled")]
    public bool? LocateDeviceUserlessDisabled { get; set; }

    [JsonPropertyName("microphoneForceMute")]
    public bool? MicrophoneForceMute { get; set; }

    [JsonPropertyName("microsoftLauncherConfigurationEnabled")]
    public bool? MicrosoftLauncherConfigurationEnabled { get; set; }

    [JsonPropertyName("microsoftLauncherCustomWallpaperAllowUserModification")]
    public bool? MicrosoftLauncherCustomWallpaperAllowUserModification { get; set; }

    [JsonPropertyName("microsoftLauncherCustomWallpaperEnabled")]
    public bool? MicrosoftLauncherCustomWallpaperEnabled { get; set; }

    [JsonPropertyName("microsoftLauncherCustomWallpaperImageUrl")]
    public string? MicrosoftLauncherCustomWallpaperImageUrl { get; set; }

    [JsonPropertyName("microsoftLauncherDockPresenceAllowUserModification")]
    public bool? MicrosoftLauncherDockPresenceAllowUserModification { get; set; }

    [JsonPropertyName("microsoftLauncherDockPresenceConfiguration")]
    public MicrosoftLauncherDockPresenceConstant? MicrosoftLauncherDockPresenceConfiguration { get; set; }

    [JsonPropertyName("microsoftLauncherFeedAllowUserModification")]
    public bool? MicrosoftLauncherFeedAllowUserModification { get; set; }

    [JsonPropertyName("microsoftLauncherFeedEnabled")]
    public bool? MicrosoftLauncherFeedEnabled { get; set; }

    [JsonPropertyName("microsoftLauncherSearchBarPlacementConfiguration")]
    public MicrosoftLauncherSearchBarPlacementConstant? MicrosoftLauncherSearchBarPlacementConfiguration { get; set; }

    [JsonPropertyName("networkEscapeHatchAllowed")]
    public bool? NetworkEscapeHatchAllowed { get; set; }

    [JsonPropertyName("nfcBlockOutgoingBeam")]
    public bool? NfcBlockOutgoingBeam { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBlockKeyguard")]
    public bool? PasswordBlockKeyguard { get; set; }

    [JsonPropertyName("passwordBlockKeyguardFeatures")]
    public List<AndroidKeyguardFeatureConstant>? PasswordBlockKeyguardFeatures { get; set; }

    [JsonPropertyName("passwordExpirationDays")]
    public int? PasswordExpirationDays { get; set; }

    [JsonPropertyName("passwordMinimumLength")]
    public int? PasswordMinimumLength { get; set; }

    [JsonPropertyName("passwordMinimumLetterCharacters")]
    public int? PasswordMinimumLetterCharacters { get; set; }

    [JsonPropertyName("passwordMinimumLowerCaseCharacters")]
    public int? PasswordMinimumLowerCaseCharacters { get; set; }

    [JsonPropertyName("passwordMinimumNonLetterCharacters")]
    public int? PasswordMinimumNonLetterCharacters { get; set; }

    [JsonPropertyName("passwordMinimumNumericCharacters")]
    public int? PasswordMinimumNumericCharacters { get; set; }

    [JsonPropertyName("passwordMinimumSymbolCharacters")]
    public int? PasswordMinimumSymbolCharacters { get; set; }

    [JsonPropertyName("passwordMinimumUpperCaseCharacters")]
    public int? PasswordMinimumUpperCaseCharacters { get; set; }

    [JsonPropertyName("passwordMinutesOfInactivityBeforeScreenTimeout")]
    public int? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }

    [JsonPropertyName("passwordPreviousPasswordCountToBlock")]
    public int? PasswordPreviousPasswordCountToBlock { get; set; }

    [JsonPropertyName("passwordRequireUnlock")]
    public AndroidDeviceOwnerRequiredPasswordUnlockConstant? PasswordRequireUnlock { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public AndroidDeviceOwnerRequiredPasswordTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("passwordSignInFailureCountBeforeFactoryReset")]
    public int? PasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("personalProfileAppsAllowInstallFromUnknownSources")]
    public bool? PersonalProfileAppsAllowInstallFromUnknownSources { get; set; }

    [JsonPropertyName("personalProfileCameraBlocked")]
    public bool? PersonalProfileCameraBlocked { get; set; }

    [JsonPropertyName("personalProfilePersonalApplications")]
    public List<AppListItemModel>? PersonalProfilePersonalApplications { get; set; }

    [JsonPropertyName("personalProfilePlayStoreMode")]
    public PersonalProfilePersonalPlayStoreModeConstant? PersonalProfilePlayStoreMode { get; set; }

    [JsonPropertyName("personalProfileScreenCaptureBlocked")]
    public bool? PersonalProfileScreenCaptureBlocked { get; set; }

    [JsonPropertyName("playStoreMode")]
    public AndroidDeviceOwnerPlayStoreModeConstant? PlayStoreMode { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("screenCaptureBlocked")]
    public bool? ScreenCaptureBlocked { get; set; }

    [JsonPropertyName("securityCommonCriteriaModeEnabled")]
    public bool? SecurityCommonCriteriaModeEnabled { get; set; }

    [JsonPropertyName("securityDeveloperSettingsEnabled")]
    public bool? SecurityDeveloperSettingsEnabled { get; set; }

    [JsonPropertyName("securityRequireVerifyApps")]
    public bool? SecurityRequireVerifyApps { get; set; }

    [JsonPropertyName("shortHelpText")]
    public AndroidDeviceOwnerUserFacingMessageModel? ShortHelpText { get; set; }

    [JsonPropertyName("statusBarBlocked")]
    public bool? StatusBarBlocked { get; set; }

    [JsonPropertyName("stayOnModes")]
    public List<AndroidDeviceOwnerBatteryPluggedModeConstant>? StayOnModes { get; set; }

    [JsonPropertyName("storageAllowUsb")]
    public bool? StorageAllowUsb { get; set; }

    [JsonPropertyName("storageBlockExternalMedia")]
    public bool? StorageBlockExternalMedia { get; set; }

    [JsonPropertyName("storageBlockUsbFileTransfer")]
    public bool? StorageBlockUsbFileTransfer { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("systemUpdateFreezePeriods")]
    public List<AndroidDeviceOwnerSystemUpdateFreezePeriodModel>? SystemUpdateFreezePeriods { get; set; }

    [JsonPropertyName("systemUpdateInstallType")]
    public AndroidDeviceOwnerSystemUpdateInstallTypeConstant? SystemUpdateInstallType { get; set; }

    [JsonPropertyName("systemUpdateWindowEndMinutesAfterMidnight")]
    public int? SystemUpdateWindowEndMinutesAfterMidnight { get; set; }

    [JsonPropertyName("systemUpdateWindowStartMinutesAfterMidnight")]
    public int? SystemUpdateWindowStartMinutesAfterMidnight { get; set; }

    [JsonPropertyName("systemWindowsBlocked")]
    public bool? SystemWindowsBlocked { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("usersBlockAdd")]
    public bool? UsersBlockAdd { get; set; }

    [JsonPropertyName("usersBlockRemove")]
    public bool? UsersBlockRemove { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("volumeBlockAdjustment")]
    public bool? VolumeBlockAdjustment { get; set; }

    [JsonPropertyName("vpnAlwaysOnLockdownMode")]
    public bool? VpnAlwaysOnLockdownMode { get; set; }

    [JsonPropertyName("vpnAlwaysOnPackageIdentifier")]
    public string? VpnAlwaysOnPackageIdentifier { get; set; }

    [JsonPropertyName("wifiBlockEditConfigurations")]
    public bool? WifiBlockEditConfigurations { get; set; }

    [JsonPropertyName("wifiBlockEditPolicyDefinedConfigurations")]
    public bool? WifiBlockEditPolicyDefinedConfigurations { get; set; }

    [JsonPropertyName("workProfilePasswordExpirationDays")]
    public int? WorkProfilePasswordExpirationDays { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumLength")]
    public int? WorkProfilePasswordMinimumLength { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumLetterCharacters")]
    public int? WorkProfilePasswordMinimumLetterCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumLowerCaseCharacters")]
    public int? WorkProfilePasswordMinimumLowerCaseCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumNonLetterCharacters")]
    public int? WorkProfilePasswordMinimumNonLetterCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumNumericCharacters")]
    public int? WorkProfilePasswordMinimumNumericCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumSymbolCharacters")]
    public int? WorkProfilePasswordMinimumSymbolCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordMinimumUpperCaseCharacters")]
    public int? WorkProfilePasswordMinimumUpperCaseCharacters { get; set; }

    [JsonPropertyName("workProfilePasswordPreviousPasswordCountToBlock")]
    public int? WorkProfilePasswordPreviousPasswordCountToBlock { get; set; }

    [JsonPropertyName("workProfilePasswordRequireUnlock")]
    public AndroidDeviceOwnerRequiredPasswordUnlockConstant? WorkProfilePasswordRequireUnlock { get; set; }

    [JsonPropertyName("workProfilePasswordRequiredType")]
    public AndroidDeviceOwnerRequiredPasswordTypeConstant? WorkProfilePasswordRequiredType { get; set; }

    [JsonPropertyName("workProfilePasswordSignInFailureCountBeforeFactoryReset")]
    public int? WorkProfilePasswordSignInFailureCountBeforeFactoryReset { get; set; }
}
