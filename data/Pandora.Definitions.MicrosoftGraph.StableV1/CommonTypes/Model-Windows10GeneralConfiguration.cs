// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class Windows10GeneralConfigurationModel
{
    [JsonPropertyName("accountsBlockAddingNonMicrosoftAccountEmail")]
    public bool? AccountsBlockAddingNonMicrosoftAccountEmail { get; set; }

    [JsonPropertyName("antiTheftModeBlocked")]
    public bool? AntiTheftModeBlocked { get; set; }

    [JsonPropertyName("appsAllowTrustedAppsSideloading")]
    public Windows10GeneralConfigurationAppsAllowTrustedAppsSideloadingConstant? AppsAllowTrustedAppsSideloading { get; set; }

    [JsonPropertyName("appsBlockWindowsStoreOriginatedApps")]
    public bool? AppsBlockWindowsStoreOriginatedApps { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bluetoothAllowedServices")]
    public List<string>? BluetoothAllowedServices { get; set; }

    [JsonPropertyName("bluetoothBlockAdvertising")]
    public bool? BluetoothBlockAdvertising { get; set; }

    [JsonPropertyName("bluetoothBlockDiscoverableMode")]
    public bool? BluetoothBlockDiscoverableMode { get; set; }

    [JsonPropertyName("bluetoothBlockPrePairing")]
    public bool? BluetoothBlockPrePairing { get; set; }

    [JsonPropertyName("bluetoothBlocked")]
    public bool? BluetoothBlocked { get; set; }

    [JsonPropertyName("cameraBlocked")]
    public bool? CameraBlocked { get; set; }

    [JsonPropertyName("cellularBlockDataWhenRoaming")]
    public bool? CellularBlockDataWhenRoaming { get; set; }

    [JsonPropertyName("cellularBlockVpn")]
    public bool? CellularBlockVpn { get; set; }

    [JsonPropertyName("cellularBlockVpnWhenRoaming")]
    public bool? CellularBlockVpnWhenRoaming { get; set; }

    [JsonPropertyName("certificatesBlockManualRootCertificateInstallation")]
    public bool? CertificatesBlockManualRootCertificateInstallation { get; set; }

    [JsonPropertyName("connectedDevicesServiceBlocked")]
    public bool? ConnectedDevicesServiceBlocked { get; set; }

    [JsonPropertyName("copyPasteBlocked")]
    public bool? CopyPasteBlocked { get; set; }

    [JsonPropertyName("cortanaBlocked")]
    public bool? CortanaBlocked { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defenderBlockEndUserAccess")]
    public bool? DefenderBlockEndUserAccess { get; set; }

    [JsonPropertyName("defenderCloudBlockLevel")]
    public Windows10GeneralConfigurationDefenderCloudBlockLevelConstant? DefenderCloudBlockLevel { get; set; }

    [JsonPropertyName("defenderDaysBeforeDeletingQuarantinedMalware")]
    public int? DefenderDaysBeforeDeletingQuarantinedMalware { get; set; }

    [JsonPropertyName("defenderDetectedMalwareActions")]
    public DefenderDetectedMalwareActionsModel? DefenderDetectedMalwareActions { get; set; }

    [JsonPropertyName("defenderFileExtensionsToExclude")]
    public List<string>? DefenderFileExtensionsToExclude { get; set; }

    [JsonPropertyName("defenderFilesAndFoldersToExclude")]
    public List<string>? DefenderFilesAndFoldersToExclude { get; set; }

    [JsonPropertyName("defenderMonitorFileActivity")]
    public Windows10GeneralConfigurationDefenderMonitorFileActivityConstant? DefenderMonitorFileActivity { get; set; }

    [JsonPropertyName("defenderProcessesToExclude")]
    public List<string>? DefenderProcessesToExclude { get; set; }

    [JsonPropertyName("defenderPromptForSampleSubmission")]
    public Windows10GeneralConfigurationDefenderPromptForSampleSubmissionConstant? DefenderPromptForSampleSubmission { get; set; }

    [JsonPropertyName("defenderRequireBehaviorMonitoring")]
    public bool? DefenderRequireBehaviorMonitoring { get; set; }

    [JsonPropertyName("defenderRequireCloudProtection")]
    public bool? DefenderRequireCloudProtection { get; set; }

    [JsonPropertyName("defenderRequireNetworkInspectionSystem")]
    public bool? DefenderRequireNetworkInspectionSystem { get; set; }

    [JsonPropertyName("defenderRequireRealTimeMonitoring")]
    public bool? DefenderRequireRealTimeMonitoring { get; set; }

    [JsonPropertyName("defenderScanArchiveFiles")]
    public bool? DefenderScanArchiveFiles { get; set; }

    [JsonPropertyName("defenderScanDownloads")]
    public bool? DefenderScanDownloads { get; set; }

    [JsonPropertyName("defenderScanIncomingMail")]
    public bool? DefenderScanIncomingMail { get; set; }

    [JsonPropertyName("defenderScanMappedNetworkDrivesDuringFullScan")]
    public bool? DefenderScanMappedNetworkDrivesDuringFullScan { get; set; }

    [JsonPropertyName("defenderScanMaxCpu")]
    public int? DefenderScanMaxCpu { get; set; }

    [JsonPropertyName("defenderScanNetworkFiles")]
    public bool? DefenderScanNetworkFiles { get; set; }

    [JsonPropertyName("defenderScanRemovableDrivesDuringFullScan")]
    public bool? DefenderScanRemovableDrivesDuringFullScan { get; set; }

    [JsonPropertyName("defenderScanScriptsLoadedInInternetExplorer")]
    public bool? DefenderScanScriptsLoadedInInternetExplorer { get; set; }

    [JsonPropertyName("defenderScanType")]
    public Windows10GeneralConfigurationDefenderScanTypeConstant? DefenderScanType { get; set; }

    [JsonPropertyName("defenderScheduledQuickScanTime")]
    public DateTime? DefenderScheduledQuickScanTime { get; set; }

    [JsonPropertyName("defenderScheduledScanTime")]
    public DateTime? DefenderScheduledScanTime { get; set; }

    [JsonPropertyName("defenderSignatureUpdateIntervalInHours")]
    public int? DefenderSignatureUpdateIntervalInHours { get; set; }

    [JsonPropertyName("defenderSystemScanSchedule")]
    public Windows10GeneralConfigurationDefenderSystemScanScheduleConstant? DefenderSystemScanSchedule { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("developerUnlockSetting")]
    public Windows10GeneralConfigurationDeveloperUnlockSettingConstant? DeveloperUnlockSetting { get; set; }

    [JsonPropertyName("deviceManagementBlockFactoryResetOnMobile")]
    public bool? DeviceManagementBlockFactoryResetOnMobile { get; set; }

    [JsonPropertyName("deviceManagementBlockManualUnenroll")]
    public bool? DeviceManagementBlockManualUnenroll { get; set; }

    [JsonPropertyName("deviceSettingStateSummaries")]
    public List<SettingStateDeviceSummaryModel>? DeviceSettingStateSummaries { get; set; }

    [JsonPropertyName("deviceStatusOverview")]
    public DeviceConfigurationDeviceOverviewModel? DeviceStatusOverview { get; set; }

    [JsonPropertyName("deviceStatuses")]
    public List<DeviceConfigurationDeviceStatusModel>? DeviceStatuses { get; set; }

    [JsonPropertyName("diagnosticsDataSubmissionMode")]
    public Windows10GeneralConfigurationDiagnosticsDataSubmissionModeConstant? DiagnosticsDataSubmissionMode { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("edgeAllowStartPagesModification")]
    public bool? EdgeAllowStartPagesModification { get; set; }

    [JsonPropertyName("edgeBlockAccessToAboutFlags")]
    public bool? EdgeBlockAccessToAboutFlags { get; set; }

    [JsonPropertyName("edgeBlockAddressBarDropdown")]
    public bool? EdgeBlockAddressBarDropdown { get; set; }

    [JsonPropertyName("edgeBlockAutofill")]
    public bool? EdgeBlockAutofill { get; set; }

    [JsonPropertyName("edgeBlockCompatibilityList")]
    public bool? EdgeBlockCompatibilityList { get; set; }

    [JsonPropertyName("edgeBlockDeveloperTools")]
    public bool? EdgeBlockDeveloperTools { get; set; }

    [JsonPropertyName("edgeBlockExtensions")]
    public bool? EdgeBlockExtensions { get; set; }

    [JsonPropertyName("edgeBlockInPrivateBrowsing")]
    public bool? EdgeBlockInPrivateBrowsing { get; set; }

    [JsonPropertyName("edgeBlockJavaScript")]
    public bool? EdgeBlockJavaScript { get; set; }

    [JsonPropertyName("edgeBlockLiveTileDataCollection")]
    public bool? EdgeBlockLiveTileDataCollection { get; set; }

    [JsonPropertyName("edgeBlockPasswordManager")]
    public bool? EdgeBlockPasswordManager { get; set; }

    [JsonPropertyName("edgeBlockPopups")]
    public bool? EdgeBlockPopups { get; set; }

    [JsonPropertyName("edgeBlockSearchSuggestions")]
    public bool? EdgeBlockSearchSuggestions { get; set; }

    [JsonPropertyName("edgeBlockSendingDoNotTrackHeader")]
    public bool? EdgeBlockSendingDoNotTrackHeader { get; set; }

    [JsonPropertyName("edgeBlockSendingIntranetTrafficToInternetExplorer")]
    public bool? EdgeBlockSendingIntranetTrafficToInternetExplorer { get; set; }

    [JsonPropertyName("edgeBlocked")]
    public bool? EdgeBlocked { get; set; }

    [JsonPropertyName("edgeClearBrowsingDataOnExit")]
    public bool? EdgeClearBrowsingDataOnExit { get; set; }

    [JsonPropertyName("edgeCookiePolicy")]
    public Windows10GeneralConfigurationEdgeCookiePolicyConstant? EdgeCookiePolicy { get; set; }

    [JsonPropertyName("edgeDisableFirstRunPage")]
    public bool? EdgeDisableFirstRunPage { get; set; }

    [JsonPropertyName("edgeEnterpriseModeSiteListLocation")]
    public string? EdgeEnterpriseModeSiteListLocation { get; set; }

    [JsonPropertyName("edgeFirstRunUrl")]
    public string? EdgeFirstRunUrl { get; set; }

    [JsonPropertyName("edgeHomepageUrls")]
    public List<string>? EdgeHomepageUrls { get; set; }

    [JsonPropertyName("edgeRequireSmartScreen")]
    public bool? EdgeRequireSmartScreen { get; set; }

    [JsonPropertyName("edgeSearchEngine")]
    public EdgeSearchEngineBaseModel? EdgeSearchEngine { get; set; }

    [JsonPropertyName("edgeSendIntranetTrafficToInternetExplorer")]
    public bool? EdgeSendIntranetTrafficToInternetExplorer { get; set; }

    [JsonPropertyName("edgeSyncFavoritesWithInternetExplorer")]
    public bool? EdgeSyncFavoritesWithInternetExplorer { get; set; }

    [JsonPropertyName("enterpriseCloudPrintDiscoveryEndPoint")]
    public string? EnterpriseCloudPrintDiscoveryEndPoint { get; set; }

    [JsonPropertyName("enterpriseCloudPrintDiscoveryMaxLimit")]
    public int? EnterpriseCloudPrintDiscoveryMaxLimit { get; set; }

    [JsonPropertyName("enterpriseCloudPrintMopriaDiscoveryResourceIdentifier")]
    public string? EnterpriseCloudPrintMopriaDiscoveryResourceIdentifier { get; set; }

    [JsonPropertyName("enterpriseCloudPrintOAuthAuthority")]
    public string? EnterpriseCloudPrintOAuthAuthority { get; set; }

    [JsonPropertyName("enterpriseCloudPrintOAuthClientIdentifier")]
    public string? EnterpriseCloudPrintOAuthClientIdentifier { get; set; }

    [JsonPropertyName("enterpriseCloudPrintResourceIdentifier")]
    public string? EnterpriseCloudPrintResourceIdentifier { get; set; }

    [JsonPropertyName("experienceBlockDeviceDiscovery")]
    public bool? ExperienceBlockDeviceDiscovery { get; set; }

    [JsonPropertyName("experienceBlockErrorDialogWhenNoSIM")]
    public bool? ExperienceBlockErrorDialogWhenNoSIM { get; set; }

    [JsonPropertyName("experienceBlockTaskSwitcher")]
    public bool? ExperienceBlockTaskSwitcher { get; set; }

    [JsonPropertyName("gameDvrBlocked")]
    public bool? GameDvrBlocked { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("internetSharingBlocked")]
    public bool? InternetSharingBlocked { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("locationServicesBlocked")]
    public bool? LocationServicesBlocked { get; set; }

    [JsonPropertyName("lockScreenAllowTimeoutConfiguration")]
    public bool? LockScreenAllowTimeoutConfiguration { get; set; }

    [JsonPropertyName("lockScreenBlockActionCenterNotifications")]
    public bool? LockScreenBlockActionCenterNotifications { get; set; }

    [JsonPropertyName("lockScreenBlockCortana")]
    public bool? LockScreenBlockCortana { get; set; }

    [JsonPropertyName("lockScreenBlockToastNotifications")]
    public bool? LockScreenBlockToastNotifications { get; set; }

    [JsonPropertyName("lockScreenTimeoutInSeconds")]
    public int? LockScreenTimeoutInSeconds { get; set; }

    [JsonPropertyName("logonBlockFastUserSwitching")]
    public bool? LogonBlockFastUserSwitching { get; set; }

    [JsonPropertyName("microsoftAccountBlockSettingsSync")]
    public bool? MicrosoftAccountBlockSettingsSync { get; set; }

    [JsonPropertyName("microsoftAccountBlocked")]
    public bool? MicrosoftAccountBlocked { get; set; }

    [JsonPropertyName("networkProxyApplySettingsDeviceWide")]
    public bool? NetworkProxyApplySettingsDeviceWide { get; set; }

    [JsonPropertyName("networkProxyAutomaticConfigurationUrl")]
    public string? NetworkProxyAutomaticConfigurationUrl { get; set; }

    [JsonPropertyName("networkProxyDisableAutoDetect")]
    public bool? NetworkProxyDisableAutoDetect { get; set; }

    [JsonPropertyName("networkProxyServer")]
    public Windows10NetworkProxyServerModel? NetworkProxyServer { get; set; }

    [JsonPropertyName("nfcBlocked")]
    public bool? NfcBlocked { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oneDriveDisableFileSync")]
    public bool? OneDriveDisableFileSync { get; set; }

    [JsonPropertyName("passwordBlockSimple")]
    public bool? PasswordBlockSimple { get; set; }

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

    [JsonPropertyName("passwordRequireWhenResumeFromIdleState")]
    public bool? PasswordRequireWhenResumeFromIdleState { get; set; }

    [JsonPropertyName("passwordRequired")]
    public bool? PasswordRequired { get; set; }

    [JsonPropertyName("passwordRequiredType")]
    public Windows10GeneralConfigurationPasswordRequiredTypeConstant? PasswordRequiredType { get; set; }

    [JsonPropertyName("passwordSignInFailureCountBeforeFactoryReset")]
    public int? PasswordSignInFailureCountBeforeFactoryReset { get; set; }

    [JsonPropertyName("personalizationDesktopImageUrl")]
    public string? PersonalizationDesktopImageUrl { get; set; }

    [JsonPropertyName("personalizationLockScreenImageUrl")]
    public string? PersonalizationLockScreenImageUrl { get; set; }

    [JsonPropertyName("privacyAdvertisingId")]
    public Windows10GeneralConfigurationPrivacyAdvertisingIdConstant? PrivacyAdvertisingId { get; set; }

    [JsonPropertyName("privacyAutoAcceptPairingAndConsentPrompts")]
    public bool? PrivacyAutoAcceptPairingAndConsentPrompts { get; set; }

    [JsonPropertyName("privacyBlockInputPersonalization")]
    public bool? PrivacyBlockInputPersonalization { get; set; }

    [JsonPropertyName("resetProtectionModeBlocked")]
    public bool? ResetProtectionModeBlocked { get; set; }

    [JsonPropertyName("safeSearchFilter")]
    public Windows10GeneralConfigurationSafeSearchFilterConstant? SafeSearchFilter { get; set; }

    [JsonPropertyName("screenCaptureBlocked")]
    public bool? ScreenCaptureBlocked { get; set; }

    [JsonPropertyName("searchBlockDiacritics")]
    public bool? SearchBlockDiacritics { get; set; }

    [JsonPropertyName("searchDisableAutoLanguageDetection")]
    public bool? SearchDisableAutoLanguageDetection { get; set; }

    [JsonPropertyName("searchDisableIndexerBackoff")]
    public bool? SearchDisableIndexerBackoff { get; set; }

    [JsonPropertyName("searchDisableIndexingEncryptedItems")]
    public bool? SearchDisableIndexingEncryptedItems { get; set; }

    [JsonPropertyName("searchDisableIndexingRemovableDrive")]
    public bool? SearchDisableIndexingRemovableDrive { get; set; }

    [JsonPropertyName("searchEnableAutomaticIndexSizeManangement")]
    public bool? SearchEnableAutomaticIndexSizeManangement { get; set; }

    [JsonPropertyName("searchEnableRemoteQueries")]
    public bool? SearchEnableRemoteQueries { get; set; }

    [JsonPropertyName("settingsBlockAccountsPage")]
    public bool? SettingsBlockAccountsPage { get; set; }

    [JsonPropertyName("settingsBlockAddProvisioningPackage")]
    public bool? SettingsBlockAddProvisioningPackage { get; set; }

    [JsonPropertyName("settingsBlockAppsPage")]
    public bool? SettingsBlockAppsPage { get; set; }

    [JsonPropertyName("settingsBlockChangeLanguage")]
    public bool? SettingsBlockChangeLanguage { get; set; }

    [JsonPropertyName("settingsBlockChangePowerSleep")]
    public bool? SettingsBlockChangePowerSleep { get; set; }

    [JsonPropertyName("settingsBlockChangeRegion")]
    public bool? SettingsBlockChangeRegion { get; set; }

    [JsonPropertyName("settingsBlockChangeSystemTime")]
    public bool? SettingsBlockChangeSystemTime { get; set; }

    [JsonPropertyName("settingsBlockDevicesPage")]
    public bool? SettingsBlockDevicesPage { get; set; }

    [JsonPropertyName("settingsBlockEaseOfAccessPage")]
    public bool? SettingsBlockEaseOfAccessPage { get; set; }

    [JsonPropertyName("settingsBlockEditDeviceName")]
    public bool? SettingsBlockEditDeviceName { get; set; }

    [JsonPropertyName("settingsBlockGamingPage")]
    public bool? SettingsBlockGamingPage { get; set; }

    [JsonPropertyName("settingsBlockNetworkInternetPage")]
    public bool? SettingsBlockNetworkInternetPage { get; set; }

    [JsonPropertyName("settingsBlockPersonalizationPage")]
    public bool? SettingsBlockPersonalizationPage { get; set; }

    [JsonPropertyName("settingsBlockPrivacyPage")]
    public bool? SettingsBlockPrivacyPage { get; set; }

    [JsonPropertyName("settingsBlockRemoveProvisioningPackage")]
    public bool? SettingsBlockRemoveProvisioningPackage { get; set; }

    [JsonPropertyName("settingsBlockSettingsApp")]
    public bool? SettingsBlockSettingsApp { get; set; }

    [JsonPropertyName("settingsBlockSystemPage")]
    public bool? SettingsBlockSystemPage { get; set; }

    [JsonPropertyName("settingsBlockTimeLanguagePage")]
    public bool? SettingsBlockTimeLanguagePage { get; set; }

    [JsonPropertyName("settingsBlockUpdateSecurityPage")]
    public bool? SettingsBlockUpdateSecurityPage { get; set; }

    [JsonPropertyName("sharedUserAppDataAllowed")]
    public bool? SharedUserAppDataAllowed { get; set; }

    [JsonPropertyName("smartScreenBlockPromptOverride")]
    public bool? SmartScreenBlockPromptOverride { get; set; }

    [JsonPropertyName("smartScreenBlockPromptOverrideForFiles")]
    public bool? SmartScreenBlockPromptOverrideForFiles { get; set; }

    [JsonPropertyName("smartScreenEnableAppInstallControl")]
    public bool? SmartScreenEnableAppInstallControl { get; set; }

    [JsonPropertyName("startBlockUnpinningAppsFromTaskbar")]
    public bool? StartBlockUnpinningAppsFromTaskbar { get; set; }

    [JsonPropertyName("startMenuAppListVisibility")]
    public Windows10GeneralConfigurationStartMenuAppListVisibilityConstant? StartMenuAppListVisibility { get; set; }

    [JsonPropertyName("startMenuHideChangeAccountSettings")]
    public bool? StartMenuHideChangeAccountSettings { get; set; }

    [JsonPropertyName("startMenuHideFrequentlyUsedApps")]
    public bool? StartMenuHideFrequentlyUsedApps { get; set; }

    [JsonPropertyName("startMenuHideHibernate")]
    public bool? StartMenuHideHibernate { get; set; }

    [JsonPropertyName("startMenuHideLock")]
    public bool? StartMenuHideLock { get; set; }

    [JsonPropertyName("startMenuHidePowerButton")]
    public bool? StartMenuHidePowerButton { get; set; }

    [JsonPropertyName("startMenuHideRecentJumpLists")]
    public bool? StartMenuHideRecentJumpLists { get; set; }

    [JsonPropertyName("startMenuHideRecentlyAddedApps")]
    public bool? StartMenuHideRecentlyAddedApps { get; set; }

    [JsonPropertyName("startMenuHideRestartOptions")]
    public bool? StartMenuHideRestartOptions { get; set; }

    [JsonPropertyName("startMenuHideShutDown")]
    public bool? StartMenuHideShutDown { get; set; }

    [JsonPropertyName("startMenuHideSignOut")]
    public bool? StartMenuHideSignOut { get; set; }

    [JsonPropertyName("startMenuHideSleep")]
    public bool? StartMenuHideSleep { get; set; }

    [JsonPropertyName("startMenuHideSwitchAccount")]
    public bool? StartMenuHideSwitchAccount { get; set; }

    [JsonPropertyName("startMenuHideUserTile")]
    public bool? StartMenuHideUserTile { get; set; }

    [JsonPropertyName("startMenuLayoutEdgeAssetsXml")]
    public string? StartMenuLayoutEdgeAssetsXml { get; set; }

    [JsonPropertyName("startMenuLayoutXml")]
    public string? StartMenuLayoutXml { get; set; }

    [JsonPropertyName("startMenuMode")]
    public Windows10GeneralConfigurationStartMenuModeConstant? StartMenuMode { get; set; }

    [JsonPropertyName("startMenuPinnedFolderDocuments")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderDocumentsConstant? StartMenuPinnedFolderDocuments { get; set; }

    [JsonPropertyName("startMenuPinnedFolderDownloads")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderDownloadsConstant? StartMenuPinnedFolderDownloads { get; set; }

    [JsonPropertyName("startMenuPinnedFolderFileExplorer")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderFileExplorerConstant? StartMenuPinnedFolderFileExplorer { get; set; }

    [JsonPropertyName("startMenuPinnedFolderHomeGroup")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderHomeGroupConstant? StartMenuPinnedFolderHomeGroup { get; set; }

    [JsonPropertyName("startMenuPinnedFolderMusic")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderMusicConstant? StartMenuPinnedFolderMusic { get; set; }

    [JsonPropertyName("startMenuPinnedFolderNetwork")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderNetworkConstant? StartMenuPinnedFolderNetwork { get; set; }

    [JsonPropertyName("startMenuPinnedFolderPersonalFolder")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderPersonalFolderConstant? StartMenuPinnedFolderPersonalFolder { get; set; }

    [JsonPropertyName("startMenuPinnedFolderPictures")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderPicturesConstant? StartMenuPinnedFolderPictures { get; set; }

    [JsonPropertyName("startMenuPinnedFolderSettings")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderSettingsConstant? StartMenuPinnedFolderSettings { get; set; }

    [JsonPropertyName("startMenuPinnedFolderVideos")]
    public Windows10GeneralConfigurationStartMenuPinnedFolderVideosConstant? StartMenuPinnedFolderVideos { get; set; }

    [JsonPropertyName("storageBlockRemovableStorage")]
    public bool? StorageBlockRemovableStorage { get; set; }

    [JsonPropertyName("storageRequireMobileDeviceEncryption")]
    public bool? StorageRequireMobileDeviceEncryption { get; set; }

    [JsonPropertyName("storageRestrictAppDataToSystemVolume")]
    public bool? StorageRestrictAppDataToSystemVolume { get; set; }

    [JsonPropertyName("storageRestrictAppInstallToSystemVolume")]
    public bool? StorageRestrictAppInstallToSystemVolume { get; set; }

    [JsonPropertyName("tenantLockdownRequireNetworkDuringOutOfBoxExperience")]
    public bool? TenantLockdownRequireNetworkDuringOutOfBoxExperience { get; set; }

    [JsonPropertyName("usbBlocked")]
    public bool? UsbBlocked { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("voiceRecordingBlocked")]
    public bool? VoiceRecordingBlocked { get; set; }

    [JsonPropertyName("webRtcBlockLocalhostIpAddress")]
    public bool? WebRtcBlockLocalhostIpAddress { get; set; }

    [JsonPropertyName("wiFiBlockAutomaticConnectHotspots")]
    public bool? WiFiBlockAutomaticConnectHotspots { get; set; }

    [JsonPropertyName("wiFiBlockManualConfiguration")]
    public bool? WiFiBlockManualConfiguration { get; set; }

    [JsonPropertyName("wiFiBlocked")]
    public bool? WiFiBlocked { get; set; }

    [JsonPropertyName("wiFiScanInterval")]
    public int? WiFiScanInterval { get; set; }

    [JsonPropertyName("windowsSpotlightBlockConsumerSpecificFeatures")]
    public bool? WindowsSpotlightBlockConsumerSpecificFeatures { get; set; }

    [JsonPropertyName("windowsSpotlightBlockOnActionCenter")]
    public bool? WindowsSpotlightBlockOnActionCenter { get; set; }

    [JsonPropertyName("windowsSpotlightBlockTailoredExperiences")]
    public bool? WindowsSpotlightBlockTailoredExperiences { get; set; }

    [JsonPropertyName("windowsSpotlightBlockThirdPartyNotifications")]
    public bool? WindowsSpotlightBlockThirdPartyNotifications { get; set; }

    [JsonPropertyName("windowsSpotlightBlockWelcomeExperience")]
    public bool? WindowsSpotlightBlockWelcomeExperience { get; set; }

    [JsonPropertyName("windowsSpotlightBlockWindowsTips")]
    public bool? WindowsSpotlightBlockWindowsTips { get; set; }

    [JsonPropertyName("windowsSpotlightBlocked")]
    public bool? WindowsSpotlightBlocked { get; set; }

    [JsonPropertyName("windowsSpotlightConfigureOnLockScreen")]
    public Windows10GeneralConfigurationWindowsSpotlightConfigureOnLockScreenConstant? WindowsSpotlightConfigureOnLockScreen { get; set; }

    [JsonPropertyName("windowsStoreBlockAutoUpdate")]
    public bool? WindowsStoreBlockAutoUpdate { get; set; }

    [JsonPropertyName("windowsStoreBlocked")]
    public bool? WindowsStoreBlocked { get; set; }

    [JsonPropertyName("windowsStoreEnablePrivateStoreOnly")]
    public bool? WindowsStoreEnablePrivateStoreOnly { get; set; }

    [JsonPropertyName("wirelessDisplayBlockProjectionToThisDevice")]
    public bool? WirelessDisplayBlockProjectionToThisDevice { get; set; }

    [JsonPropertyName("wirelessDisplayBlockUserInputFromReceiver")]
    public bool? WirelessDisplayBlockUserInputFromReceiver { get; set; }

    [JsonPropertyName("wirelessDisplayRequirePinForPairing")]
    public bool? WirelessDisplayRequirePinForPairing { get; set; }
}
