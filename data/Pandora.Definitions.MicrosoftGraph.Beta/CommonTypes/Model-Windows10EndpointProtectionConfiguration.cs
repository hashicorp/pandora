// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10EndpointProtectionConfigurationModel
{
    [JsonPropertyName("appLockerApplicationControl")]
    public Windows10EndpointProtectionConfigurationAppLockerApplicationControlConstant? AppLockerApplicationControl { get; set; }

    [JsonPropertyName("applicationGuardAllowCameraMicrophoneRedirection")]
    public bool? ApplicationGuardAllowCameraMicrophoneRedirection { get; set; }

    [JsonPropertyName("applicationGuardAllowFileSaveOnHost")]
    public bool? ApplicationGuardAllowFileSaveOnHost { get; set; }

    [JsonPropertyName("applicationGuardAllowPersistence")]
    public bool? ApplicationGuardAllowPersistence { get; set; }

    [JsonPropertyName("applicationGuardAllowPrintToLocalPrinters")]
    public bool? ApplicationGuardAllowPrintToLocalPrinters { get; set; }

    [JsonPropertyName("applicationGuardAllowPrintToNetworkPrinters")]
    public bool? ApplicationGuardAllowPrintToNetworkPrinters { get; set; }

    [JsonPropertyName("applicationGuardAllowPrintToPDF")]
    public bool? ApplicationGuardAllowPrintToPDF { get; set; }

    [JsonPropertyName("applicationGuardAllowPrintToXPS")]
    public bool? ApplicationGuardAllowPrintToXPS { get; set; }

    [JsonPropertyName("applicationGuardAllowVirtualGPU")]
    public bool? ApplicationGuardAllowVirtualGPU { get; set; }

    [JsonPropertyName("applicationGuardBlockClipboardSharing")]
    public Windows10EndpointProtectionConfigurationApplicationGuardBlockClipboardSharingConstant? ApplicationGuardBlockClipboardSharing { get; set; }

    [JsonPropertyName("applicationGuardBlockFileTransfer")]
    public Windows10EndpointProtectionConfigurationApplicationGuardBlockFileTransferConstant? ApplicationGuardBlockFileTransfer { get; set; }

    [JsonPropertyName("applicationGuardBlockNonEnterpriseContent")]
    public bool? ApplicationGuardBlockNonEnterpriseContent { get; set; }

    [JsonPropertyName("applicationGuardCertificateThumbprints")]
    public List<string>? ApplicationGuardCertificateThumbprints { get; set; }

    [JsonPropertyName("applicationGuardEnabled")]
    public bool? ApplicationGuardEnabled { get; set; }

    [JsonPropertyName("applicationGuardEnabledOptions")]
    public Windows10EndpointProtectionConfigurationApplicationGuardEnabledOptionsConstant? ApplicationGuardEnabledOptions { get; set; }

    [JsonPropertyName("applicationGuardForceAuditing")]
    public bool? ApplicationGuardForceAuditing { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bitLockerAllowStandardUserEncryption")]
    public bool? BitLockerAllowStandardUserEncryption { get; set; }

    [JsonPropertyName("bitLockerDisableWarningForOtherDiskEncryption")]
    public bool? BitLockerDisableWarningForOtherDiskEncryption { get; set; }

    [JsonPropertyName("bitLockerEnableStorageCardEncryptionOnMobile")]
    public bool? BitLockerEnableStorageCardEncryptionOnMobile { get; set; }

    [JsonPropertyName("bitLockerEncryptDevice")]
    public bool? BitLockerEncryptDevice { get; set; }

    [JsonPropertyName("bitLockerFixedDrivePolicy")]
    public BitLockerFixedDrivePolicyModel? BitLockerFixedDrivePolicy { get; set; }

    [JsonPropertyName("bitLockerRecoveryPasswordRotation")]
    public Windows10EndpointProtectionConfigurationBitLockerRecoveryPasswordRotationConstant? BitLockerRecoveryPasswordRotation { get; set; }

    [JsonPropertyName("bitLockerRemovableDrivePolicy")]
    public BitLockerRemovableDrivePolicyModel? BitLockerRemovableDrivePolicy { get; set; }

    [JsonPropertyName("bitLockerSystemDrivePolicy")]
    public BitLockerSystemDrivePolicyModel? BitLockerSystemDrivePolicy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defenderAdditionalGuardedFolders")]
    public List<string>? DefenderAdditionalGuardedFolders { get; set; }

    [JsonPropertyName("defenderAdobeReaderLaunchChildProcess")]
    public Windows10EndpointProtectionConfigurationDefenderAdobeReaderLaunchChildProcessConstant? DefenderAdobeReaderLaunchChildProcess { get; set; }

    [JsonPropertyName("defenderAdvancedRansomewareProtectionType")]
    public Windows10EndpointProtectionConfigurationDefenderAdvancedRansomewareProtectionTypeConstant? DefenderAdvancedRansomewareProtectionType { get; set; }

    [JsonPropertyName("defenderAllowBehaviorMonitoring")]
    public bool? DefenderAllowBehaviorMonitoring { get; set; }

    [JsonPropertyName("defenderAllowCloudProtection")]
    public bool? DefenderAllowCloudProtection { get; set; }

    [JsonPropertyName("defenderAllowEndUserAccess")]
    public bool? DefenderAllowEndUserAccess { get; set; }

    [JsonPropertyName("defenderAllowIntrusionPreventionSystem")]
    public bool? DefenderAllowIntrusionPreventionSystem { get; set; }

    [JsonPropertyName("defenderAllowOnAccessProtection")]
    public bool? DefenderAllowOnAccessProtection { get; set; }

    [JsonPropertyName("defenderAllowRealTimeMonitoring")]
    public bool? DefenderAllowRealTimeMonitoring { get; set; }

    [JsonPropertyName("defenderAllowScanArchiveFiles")]
    public bool? DefenderAllowScanArchiveFiles { get; set; }

    [JsonPropertyName("defenderAllowScanDownloads")]
    public bool? DefenderAllowScanDownloads { get; set; }

    [JsonPropertyName("defenderAllowScanNetworkFiles")]
    public bool? DefenderAllowScanNetworkFiles { get; set; }

    [JsonPropertyName("defenderAllowScanRemovableDrivesDuringFullScan")]
    public bool? DefenderAllowScanRemovableDrivesDuringFullScan { get; set; }

    [JsonPropertyName("defenderAllowScanScriptsLoadedInInternetExplorer")]
    public bool? DefenderAllowScanScriptsLoadedInInternetExplorer { get; set; }

    [JsonPropertyName("defenderAttackSurfaceReductionExcludedPaths")]
    public List<string>? DefenderAttackSurfaceReductionExcludedPaths { get; set; }

    [JsonPropertyName("defenderBlockEndUserAccess")]
    public bool? DefenderBlockEndUserAccess { get; set; }

    [JsonPropertyName("defenderBlockPersistenceThroughWmiType")]
    public Windows10EndpointProtectionConfigurationDefenderBlockPersistenceThroughWmiTypeConstant? DefenderBlockPersistenceThroughWmiType { get; set; }

    [JsonPropertyName("defenderCheckForSignaturesBeforeRunningScan")]
    public bool? DefenderCheckForSignaturesBeforeRunningScan { get; set; }

    [JsonPropertyName("defenderCloudBlockLevel")]
    public Windows10EndpointProtectionConfigurationDefenderCloudBlockLevelConstant? DefenderCloudBlockLevel { get; set; }

    [JsonPropertyName("defenderCloudExtendedTimeoutInSeconds")]
    public int? DefenderCloudExtendedTimeoutInSeconds { get; set; }

    [JsonPropertyName("defenderDaysBeforeDeletingQuarantinedMalware")]
    public int? DefenderDaysBeforeDeletingQuarantinedMalware { get; set; }

    [JsonPropertyName("defenderDetectedMalwareActions")]
    public DefenderDetectedMalwareActionsModel? DefenderDetectedMalwareActions { get; set; }

    [JsonPropertyName("defenderDisableBehaviorMonitoring")]
    public bool? DefenderDisableBehaviorMonitoring { get; set; }

    [JsonPropertyName("defenderDisableCatchupFullScan")]
    public bool? DefenderDisableCatchupFullScan { get; set; }

    [JsonPropertyName("defenderDisableCatchupQuickScan")]
    public bool? DefenderDisableCatchupQuickScan { get; set; }

    [JsonPropertyName("defenderDisableCloudProtection")]
    public bool? DefenderDisableCloudProtection { get; set; }

    [JsonPropertyName("defenderDisableIntrusionPreventionSystem")]
    public bool? DefenderDisableIntrusionPreventionSystem { get; set; }

    [JsonPropertyName("defenderDisableOnAccessProtection")]
    public bool? DefenderDisableOnAccessProtection { get; set; }

    [JsonPropertyName("defenderDisableRealTimeMonitoring")]
    public bool? DefenderDisableRealTimeMonitoring { get; set; }

    [JsonPropertyName("defenderDisableScanArchiveFiles")]
    public bool? DefenderDisableScanArchiveFiles { get; set; }

    [JsonPropertyName("defenderDisableScanDownloads")]
    public bool? DefenderDisableScanDownloads { get; set; }

    [JsonPropertyName("defenderDisableScanNetworkFiles")]
    public bool? DefenderDisableScanNetworkFiles { get; set; }

    [JsonPropertyName("defenderDisableScanRemovableDrivesDuringFullScan")]
    public bool? DefenderDisableScanRemovableDrivesDuringFullScan { get; set; }

    [JsonPropertyName("defenderDisableScanScriptsLoadedInInternetExplorer")]
    public bool? DefenderDisableScanScriptsLoadedInInternetExplorer { get; set; }

    [JsonPropertyName("defenderEmailContentExecution")]
    public Windows10EndpointProtectionConfigurationDefenderEmailContentExecutionConstant? DefenderEmailContentExecution { get; set; }

    [JsonPropertyName("defenderEmailContentExecutionType")]
    public Windows10EndpointProtectionConfigurationDefenderEmailContentExecutionTypeConstant? DefenderEmailContentExecutionType { get; set; }

    [JsonPropertyName("defenderEnableLowCpuPriority")]
    public bool? DefenderEnableLowCpuPriority { get; set; }

    [JsonPropertyName("defenderEnableScanIncomingMail")]
    public bool? DefenderEnableScanIncomingMail { get; set; }

    [JsonPropertyName("defenderEnableScanMappedNetworkDrivesDuringFullScan")]
    public bool? DefenderEnableScanMappedNetworkDrivesDuringFullScan { get; set; }

    [JsonPropertyName("defenderExploitProtectionXml")]
    public string? DefenderExploitProtectionXml { get; set; }

    [JsonPropertyName("defenderExploitProtectionXmlFileName")]
    public string? DefenderExploitProtectionXmlFileName { get; set; }

    [JsonPropertyName("defenderFileExtensionsToExclude")]
    public List<string>? DefenderFileExtensionsToExclude { get; set; }

    [JsonPropertyName("defenderFilesAndFoldersToExclude")]
    public List<string>? DefenderFilesAndFoldersToExclude { get; set; }

    [JsonPropertyName("defenderGuardMyFoldersType")]
    public Windows10EndpointProtectionConfigurationDefenderGuardMyFoldersTypeConstant? DefenderGuardMyFoldersType { get; set; }

    [JsonPropertyName("defenderGuardedFoldersAllowedAppPaths")]
    public List<string>? DefenderGuardedFoldersAllowedAppPaths { get; set; }

    [JsonPropertyName("defenderNetworkProtectionType")]
    public Windows10EndpointProtectionConfigurationDefenderNetworkProtectionTypeConstant? DefenderNetworkProtectionType { get; set; }

    [JsonPropertyName("defenderOfficeAppsExecutableContentCreationOrLaunch")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeAppsExecutableContentCreationOrLaunchConstant? DefenderOfficeAppsExecutableContentCreationOrLaunch { get; set; }

    [JsonPropertyName("defenderOfficeAppsExecutableContentCreationOrLaunchType")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeAppsExecutableContentCreationOrLaunchTypeConstant? DefenderOfficeAppsExecutableContentCreationOrLaunchType { get; set; }

    [JsonPropertyName("defenderOfficeAppsLaunchChildProcess")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeAppsLaunchChildProcessConstant? DefenderOfficeAppsLaunchChildProcess { get; set; }

    [JsonPropertyName("defenderOfficeAppsLaunchChildProcessType")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeAppsLaunchChildProcessTypeConstant? DefenderOfficeAppsLaunchChildProcessType { get; set; }

    [JsonPropertyName("defenderOfficeAppsOtherProcessInjection")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeAppsOtherProcessInjectionConstant? DefenderOfficeAppsOtherProcessInjection { get; set; }

    [JsonPropertyName("defenderOfficeAppsOtherProcessInjectionType")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeAppsOtherProcessInjectionTypeConstant? DefenderOfficeAppsOtherProcessInjectionType { get; set; }

    [JsonPropertyName("defenderOfficeCommunicationAppsLaunchChildProcess")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeCommunicationAppsLaunchChildProcessConstant? DefenderOfficeCommunicationAppsLaunchChildProcess { get; set; }

    [JsonPropertyName("defenderOfficeMacroCodeAllowWin32Imports")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeMacroCodeAllowWin32ImportsConstant? DefenderOfficeMacroCodeAllowWin32Imports { get; set; }

    [JsonPropertyName("defenderOfficeMacroCodeAllowWin32ImportsType")]
    public Windows10EndpointProtectionConfigurationDefenderOfficeMacroCodeAllowWin32ImportsTypeConstant? DefenderOfficeMacroCodeAllowWin32ImportsType { get; set; }

    [JsonPropertyName("defenderPotentiallyUnwantedAppAction")]
    public Windows10EndpointProtectionConfigurationDefenderPotentiallyUnwantedAppActionConstant? DefenderPotentiallyUnwantedAppAction { get; set; }

    [JsonPropertyName("defenderPreventCredentialStealingType")]
    public Windows10EndpointProtectionConfigurationDefenderPreventCredentialStealingTypeConstant? DefenderPreventCredentialStealingType { get; set; }

    [JsonPropertyName("defenderProcessCreation")]
    public Windows10EndpointProtectionConfigurationDefenderProcessCreationConstant? DefenderProcessCreation { get; set; }

    [JsonPropertyName("defenderProcessCreationType")]
    public Windows10EndpointProtectionConfigurationDefenderProcessCreationTypeConstant? DefenderProcessCreationType { get; set; }

    [JsonPropertyName("defenderProcessesToExclude")]
    public List<string>? DefenderProcessesToExclude { get; set; }

    [JsonPropertyName("defenderScanDirection")]
    public Windows10EndpointProtectionConfigurationDefenderScanDirectionConstant? DefenderScanDirection { get; set; }

    [JsonPropertyName("defenderScanMaxCpuPercentage")]
    public int? DefenderScanMaxCpuPercentage { get; set; }

    [JsonPropertyName("defenderScanType")]
    public Windows10EndpointProtectionConfigurationDefenderScanTypeConstant? DefenderScanType { get; set; }

    [JsonPropertyName("defenderScheduledQuickScanTime")]
    public DateTime? DefenderScheduledQuickScanTime { get; set; }

    [JsonPropertyName("defenderScheduledScanDay")]
    public Windows10EndpointProtectionConfigurationDefenderScheduledScanDayConstant? DefenderScheduledScanDay { get; set; }

    [JsonPropertyName("defenderScheduledScanTime")]
    public DateTime? DefenderScheduledScanTime { get; set; }

    [JsonPropertyName("defenderScriptDownloadedPayloadExecution")]
    public Windows10EndpointProtectionConfigurationDefenderScriptDownloadedPayloadExecutionConstant? DefenderScriptDownloadedPayloadExecution { get; set; }

    [JsonPropertyName("defenderScriptDownloadedPayloadExecutionType")]
    public Windows10EndpointProtectionConfigurationDefenderScriptDownloadedPayloadExecutionTypeConstant? DefenderScriptDownloadedPayloadExecutionType { get; set; }

    [JsonPropertyName("defenderScriptObfuscatedMacroCode")]
    public Windows10EndpointProtectionConfigurationDefenderScriptObfuscatedMacroCodeConstant? DefenderScriptObfuscatedMacroCode { get; set; }

    [JsonPropertyName("defenderScriptObfuscatedMacroCodeType")]
    public Windows10EndpointProtectionConfigurationDefenderScriptObfuscatedMacroCodeTypeConstant? DefenderScriptObfuscatedMacroCodeType { get; set; }

    [JsonPropertyName("defenderSecurityCenterBlockExploitProtectionOverride")]
    public bool? DefenderSecurityCenterBlockExploitProtectionOverride { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableAccountUI")]
    public bool? DefenderSecurityCenterDisableAccountUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableAppBrowserUI")]
    public bool? DefenderSecurityCenterDisableAppBrowserUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableClearTpmUI")]
    public bool? DefenderSecurityCenterDisableClearTpmUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableFamilyUI")]
    public bool? DefenderSecurityCenterDisableFamilyUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableHardwareUI")]
    public bool? DefenderSecurityCenterDisableHardwareUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableHealthUI")]
    public bool? DefenderSecurityCenterDisableHealthUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableNetworkUI")]
    public bool? DefenderSecurityCenterDisableNetworkUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableNotificationAreaUI")]
    public bool? DefenderSecurityCenterDisableNotificationAreaUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableRansomwareUI")]
    public bool? DefenderSecurityCenterDisableRansomwareUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableSecureBootUI")]
    public bool? DefenderSecurityCenterDisableSecureBootUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableTroubleshootingUI")]
    public bool? DefenderSecurityCenterDisableTroubleshootingUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableVirusUI")]
    public bool? DefenderSecurityCenterDisableVirusUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterDisableVulnerableTpmFirmwareUpdateUI")]
    public bool? DefenderSecurityCenterDisableVulnerableTpmFirmwareUpdateUI { get; set; }

    [JsonPropertyName("defenderSecurityCenterHelpEmail")]
    public string? DefenderSecurityCenterHelpEmail { get; set; }

    [JsonPropertyName("defenderSecurityCenterHelpPhone")]
    public string? DefenderSecurityCenterHelpPhone { get; set; }

    [JsonPropertyName("defenderSecurityCenterHelpURL")]
    public string? DefenderSecurityCenterHelpURL { get; set; }

    [JsonPropertyName("defenderSecurityCenterITContactDisplay")]
    public Windows10EndpointProtectionConfigurationDefenderSecurityCenterITContactDisplayConstant? DefenderSecurityCenterITContactDisplay { get; set; }

    [JsonPropertyName("defenderSecurityCenterNotificationsFromApp")]
    public Windows10EndpointProtectionConfigurationDefenderSecurityCenterNotificationsFromAppConstant? DefenderSecurityCenterNotificationsFromApp { get; set; }

    [JsonPropertyName("defenderSecurityCenterOrganizationDisplayName")]
    public string? DefenderSecurityCenterOrganizationDisplayName { get; set; }

    [JsonPropertyName("defenderSignatureUpdateIntervalInHours")]
    public int? DefenderSignatureUpdateIntervalInHours { get; set; }

    [JsonPropertyName("defenderSubmitSamplesConsentType")]
    public Windows10EndpointProtectionConfigurationDefenderSubmitSamplesConsentTypeConstant? DefenderSubmitSamplesConsentType { get; set; }

    [JsonPropertyName("defenderUntrustedExecutable")]
    public Windows10EndpointProtectionConfigurationDefenderUntrustedExecutableConstant? DefenderUntrustedExecutable { get; set; }

    [JsonPropertyName("defenderUntrustedExecutableType")]
    public Windows10EndpointProtectionConfigurationDefenderUntrustedExecutableTypeConstant? DefenderUntrustedExecutableType { get; set; }

    [JsonPropertyName("defenderUntrustedUSBProcess")]
    public Windows10EndpointProtectionConfigurationDefenderUntrustedUSBProcessConstant? DefenderUntrustedUSBProcess { get; set; }

    [JsonPropertyName("defenderUntrustedUSBProcessType")]
    public Windows10EndpointProtectionConfigurationDefenderUntrustedUSBProcessTypeConstant? DefenderUntrustedUSBProcessType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceGuardEnableSecureBootWithDMA")]
    public bool? DeviceGuardEnableSecureBootWithDMA { get; set; }

    [JsonPropertyName("deviceGuardEnableVirtualizationBasedSecurity")]
    public bool? DeviceGuardEnableVirtualizationBasedSecurity { get; set; }

    [JsonPropertyName("deviceGuardLaunchSystemGuard")]
    public Windows10EndpointProtectionConfigurationDeviceGuardLaunchSystemGuardConstant? DeviceGuardLaunchSystemGuard { get; set; }

    [JsonPropertyName("deviceGuardLocalSystemAuthorityCredentialGuardSettings")]
    public Windows10EndpointProtectionConfigurationDeviceGuardLocalSystemAuthorityCredentialGuardSettingsConstant? DeviceGuardLocalSystemAuthorityCredentialGuardSettings { get; set; }

    [JsonPropertyName("deviceGuardSecureBootWithDMA")]
    public Windows10EndpointProtectionConfigurationDeviceGuardSecureBootWithDMAConstant? DeviceGuardSecureBootWithDMA { get; set; }

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

    [JsonPropertyName("dmaGuardDeviceEnumerationPolicy")]
    public Windows10EndpointProtectionConfigurationDmaGuardDeviceEnumerationPolicyConstant? DmaGuardDeviceEnumerationPolicy { get; set; }

    [JsonPropertyName("firewallBlockStatefulFTP")]
    public bool? FirewallBlockStatefulFTP { get; set; }

    [JsonPropertyName("firewallCertificateRevocationListCheckMethod")]
    public Windows10EndpointProtectionConfigurationFirewallCertificateRevocationListCheckMethodConstant? FirewallCertificateRevocationListCheckMethod { get; set; }

    [JsonPropertyName("firewallIPSecExemptionsAllowDHCP")]
    public bool? FirewallIPSecExemptionsAllowDHCP { get; set; }

    [JsonPropertyName("firewallIPSecExemptionsAllowICMP")]
    public bool? FirewallIPSecExemptionsAllowICMP { get; set; }

    [JsonPropertyName("firewallIPSecExemptionsAllowNeighborDiscovery")]
    public bool? FirewallIPSecExemptionsAllowNeighborDiscovery { get; set; }

    [JsonPropertyName("firewallIPSecExemptionsAllowRouterDiscovery")]
    public bool? FirewallIPSecExemptionsAllowRouterDiscovery { get; set; }

    [JsonPropertyName("firewallIPSecExemptionsNone")]
    public bool? FirewallIPSecExemptionsNone { get; set; }

    [JsonPropertyName("firewallIdleTimeoutForSecurityAssociationInSeconds")]
    public int? FirewallIdleTimeoutForSecurityAssociationInSeconds { get; set; }

    [JsonPropertyName("firewallMergeKeyingModuleSettings")]
    public bool? FirewallMergeKeyingModuleSettings { get; set; }

    [JsonPropertyName("firewallPacketQueueingMethod")]
    public Windows10EndpointProtectionConfigurationFirewallPacketQueueingMethodConstant? FirewallPacketQueueingMethod { get; set; }

    [JsonPropertyName("firewallPreSharedKeyEncodingMethod")]
    public Windows10EndpointProtectionConfigurationFirewallPreSharedKeyEncodingMethodConstant? FirewallPreSharedKeyEncodingMethod { get; set; }

    [JsonPropertyName("firewallProfileDomain")]
    public WindowsFirewallNetworkProfileModel? FirewallProfileDomain { get; set; }

    [JsonPropertyName("firewallProfilePrivate")]
    public WindowsFirewallNetworkProfileModel? FirewallProfilePrivate { get; set; }

    [JsonPropertyName("firewallProfilePublic")]
    public WindowsFirewallNetworkProfileModel? FirewallProfilePublic { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<WindowsFirewallRuleModel>? FirewallRules { get; set; }

    [JsonPropertyName("groupAssignments")]
    public List<DeviceConfigurationGroupAssignmentModel>? GroupAssignments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lanManagerAuthenticationLevel")]
    public Windows10EndpointProtectionConfigurationLanManagerAuthenticationLevelConstant? LanManagerAuthenticationLevel { get; set; }

    [JsonPropertyName("lanManagerWorkstationDisableInsecureGuestLogons")]
    public bool? LanManagerWorkstationDisableInsecureGuestLogons { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("localSecurityOptionsAdministratorAccountName")]
    public string? LocalSecurityOptionsAdministratorAccountName { get; set; }

    [JsonPropertyName("localSecurityOptionsAdministratorElevationPromptBehavior")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsAdministratorElevationPromptBehaviorConstant? LocalSecurityOptionsAdministratorElevationPromptBehavior { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowAnonymousEnumerationOfSAMAccountsAndShares")]
    public bool? LocalSecurityOptionsAllowAnonymousEnumerationOfSAMAccountsAndShares { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowPKU2UAuthenticationRequests")]
    public bool? LocalSecurityOptionsAllowPKU2UAuthenticationRequests { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowRemoteCallsToSecurityAccountsManager")]
    public string? LocalSecurityOptionsAllowRemoteCallsToSecurityAccountsManager { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowRemoteCallsToSecurityAccountsManagerHelperBool")]
    public bool? LocalSecurityOptionsAllowRemoteCallsToSecurityAccountsManagerHelperBool { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowSystemToBeShutDownWithoutHavingToLogOn")]
    public bool? LocalSecurityOptionsAllowSystemToBeShutDownWithoutHavingToLogOn { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowUIAccessApplicationElevation")]
    public bool? LocalSecurityOptionsAllowUIAccessApplicationElevation { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowUIAccessApplicationsForSecureLocations")]
    public bool? LocalSecurityOptionsAllowUIAccessApplicationsForSecureLocations { get; set; }

    [JsonPropertyName("localSecurityOptionsAllowUndockWithoutHavingToLogon")]
    public bool? LocalSecurityOptionsAllowUndockWithoutHavingToLogon { get; set; }

    [JsonPropertyName("localSecurityOptionsBlockMicrosoftAccounts")]
    public bool? LocalSecurityOptionsBlockMicrosoftAccounts { get; set; }

    [JsonPropertyName("localSecurityOptionsBlockRemoteLogonWithBlankPassword")]
    public bool? LocalSecurityOptionsBlockRemoteLogonWithBlankPassword { get; set; }

    [JsonPropertyName("localSecurityOptionsBlockRemoteOpticalDriveAccess")]
    public bool? LocalSecurityOptionsBlockRemoteOpticalDriveAccess { get; set; }

    [JsonPropertyName("localSecurityOptionsBlockUsersInstallingPrinterDrivers")]
    public bool? LocalSecurityOptionsBlockUsersInstallingPrinterDrivers { get; set; }

    [JsonPropertyName("localSecurityOptionsClearVirtualMemoryPageFile")]
    public bool? LocalSecurityOptionsClearVirtualMemoryPageFile { get; set; }

    [JsonPropertyName("localSecurityOptionsClientDigitallySignCommunicationsAlways")]
    public bool? LocalSecurityOptionsClientDigitallySignCommunicationsAlways { get; set; }

    [JsonPropertyName("localSecurityOptionsClientSendUnencryptedPasswordToThirdPartySMBServers")]
    public bool? LocalSecurityOptionsClientSendUnencryptedPasswordToThirdPartySMBServers { get; set; }

    [JsonPropertyName("localSecurityOptionsDetectApplicationInstallationsAndPromptForElevation")]
    public bool? LocalSecurityOptionsDetectApplicationInstallationsAndPromptForElevation { get; set; }

    [JsonPropertyName("localSecurityOptionsDisableAdministratorAccount")]
    public bool? LocalSecurityOptionsDisableAdministratorAccount { get; set; }

    [JsonPropertyName("localSecurityOptionsDisableClientDigitallySignCommunicationsIfServerAgrees")]
    public bool? LocalSecurityOptionsDisableClientDigitallySignCommunicationsIfServerAgrees { get; set; }

    [JsonPropertyName("localSecurityOptionsDisableGuestAccount")]
    public bool? LocalSecurityOptionsDisableGuestAccount { get; set; }

    [JsonPropertyName("localSecurityOptionsDisableServerDigitallySignCommunicationsAlways")]
    public bool? LocalSecurityOptionsDisableServerDigitallySignCommunicationsAlways { get; set; }

    [JsonPropertyName("localSecurityOptionsDisableServerDigitallySignCommunicationsIfClientAgrees")]
    public bool? LocalSecurityOptionsDisableServerDigitallySignCommunicationsIfClientAgrees { get; set; }

    [JsonPropertyName("localSecurityOptionsDoNotAllowAnonymousEnumerationOfSAMAccounts")]
    public bool? LocalSecurityOptionsDoNotAllowAnonymousEnumerationOfSAMAccounts { get; set; }

    [JsonPropertyName("localSecurityOptionsDoNotRequireCtrlAltDel")]
    public bool? LocalSecurityOptionsDoNotRequireCtrlAltDel { get; set; }

    [JsonPropertyName("localSecurityOptionsDoNotStoreLANManagerHashValueOnNextPasswordChange")]
    public bool? LocalSecurityOptionsDoNotStoreLANManagerHashValueOnNextPasswordChange { get; set; }

    [JsonPropertyName("localSecurityOptionsFormatAndEjectOfRemovableMediaAllowedUser")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsFormatAndEjectOfRemovableMediaAllowedUserConstant? LocalSecurityOptionsFormatAndEjectOfRemovableMediaAllowedUser { get; set; }

    [JsonPropertyName("localSecurityOptionsGuestAccountName")]
    public string? LocalSecurityOptionsGuestAccountName { get; set; }

    [JsonPropertyName("localSecurityOptionsHideLastSignedInUser")]
    public bool? LocalSecurityOptionsHideLastSignedInUser { get; set; }

    [JsonPropertyName("localSecurityOptionsHideUsernameAtSignIn")]
    public bool? LocalSecurityOptionsHideUsernameAtSignIn { get; set; }

    [JsonPropertyName("localSecurityOptionsInformationDisplayedOnLockScreen")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsInformationDisplayedOnLockScreenConstant? LocalSecurityOptionsInformationDisplayedOnLockScreen { get; set; }

    [JsonPropertyName("localSecurityOptionsInformationShownOnLockScreen")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsInformationShownOnLockScreenConstant? LocalSecurityOptionsInformationShownOnLockScreen { get; set; }

    [JsonPropertyName("localSecurityOptionsLogOnMessageText")]
    public string? LocalSecurityOptionsLogOnMessageText { get; set; }

    [JsonPropertyName("localSecurityOptionsLogOnMessageTitle")]
    public string? LocalSecurityOptionsLogOnMessageTitle { get; set; }

    [JsonPropertyName("localSecurityOptionsMachineInactivityLimit")]
    public int? LocalSecurityOptionsMachineInactivityLimit { get; set; }

    [JsonPropertyName("localSecurityOptionsMachineInactivityLimitInMinutes")]
    public int? LocalSecurityOptionsMachineInactivityLimitInMinutes { get; set; }

    [JsonPropertyName("localSecurityOptionsMinimumSessionSecurityForNtlmSspBasedClients")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsMinimumSessionSecurityForNtlmSspBasedClientsConstant? LocalSecurityOptionsMinimumSessionSecurityForNtlmSspBasedClients { get; set; }

    [JsonPropertyName("localSecurityOptionsMinimumSessionSecurityForNtlmSspBasedServers")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsMinimumSessionSecurityForNtlmSspBasedServersConstant? LocalSecurityOptionsMinimumSessionSecurityForNtlmSspBasedServers { get; set; }

    [JsonPropertyName("localSecurityOptionsOnlyElevateSignedExecutables")]
    public bool? LocalSecurityOptionsOnlyElevateSignedExecutables { get; set; }

    [JsonPropertyName("localSecurityOptionsRestrictAnonymousAccessToNamedPipesAndShares")]
    public bool? LocalSecurityOptionsRestrictAnonymousAccessToNamedPipesAndShares { get; set; }

    [JsonPropertyName("localSecurityOptionsSmartCardRemovalBehavior")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsSmartCardRemovalBehaviorConstant? LocalSecurityOptionsSmartCardRemovalBehavior { get; set; }

    [JsonPropertyName("localSecurityOptionsStandardUserElevationPromptBehavior")]
    public Windows10EndpointProtectionConfigurationLocalSecurityOptionsStandardUserElevationPromptBehaviorConstant? LocalSecurityOptionsStandardUserElevationPromptBehavior { get; set; }

    [JsonPropertyName("localSecurityOptionsSwitchToSecureDesktopWhenPromptingForElevation")]
    public bool? LocalSecurityOptionsSwitchToSecureDesktopWhenPromptingForElevation { get; set; }

    [JsonPropertyName("localSecurityOptionsUseAdminApprovalMode")]
    public bool? LocalSecurityOptionsUseAdminApprovalMode { get; set; }

    [JsonPropertyName("localSecurityOptionsUseAdminApprovalModeForAdministrators")]
    public bool? LocalSecurityOptionsUseAdminApprovalModeForAdministrators { get; set; }

    [JsonPropertyName("localSecurityOptionsVirtualizeFileAndRegistryWriteFailuresToPerUserLocations")]
    public bool? LocalSecurityOptionsVirtualizeFileAndRegistryWriteFailuresToPerUserLocations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("smartScreenBlockOverrideForFiles")]
    public bool? SmartScreenBlockOverrideForFiles { get; set; }

    [JsonPropertyName("smartScreenEnableInShell")]
    public bool? SmartScreenEnableInShell { get; set; }

    [JsonPropertyName("supportsScopeTags")]
    public bool? SupportsScopeTags { get; set; }

    [JsonPropertyName("userRightsAccessCredentialManagerAsTrustedCaller")]
    public DeviceManagementUserRightsSettingModel? UserRightsAccessCredentialManagerAsTrustedCaller { get; set; }

    [JsonPropertyName("userRightsActAsPartOfTheOperatingSystem")]
    public DeviceManagementUserRightsSettingModel? UserRightsActAsPartOfTheOperatingSystem { get; set; }

    [JsonPropertyName("userRightsAllowAccessFromNetwork")]
    public DeviceManagementUserRightsSettingModel? UserRightsAllowAccessFromNetwork { get; set; }

    [JsonPropertyName("userRightsBackupData")]
    public DeviceManagementUserRightsSettingModel? UserRightsBackupData { get; set; }

    [JsonPropertyName("userRightsBlockAccessFromNetwork")]
    public DeviceManagementUserRightsSettingModel? UserRightsBlockAccessFromNetwork { get; set; }

    [JsonPropertyName("userRightsChangeSystemTime")]
    public DeviceManagementUserRightsSettingModel? UserRightsChangeSystemTime { get; set; }

    [JsonPropertyName("userRightsCreateGlobalObjects")]
    public DeviceManagementUserRightsSettingModel? UserRightsCreateGlobalObjects { get; set; }

    [JsonPropertyName("userRightsCreatePageFile")]
    public DeviceManagementUserRightsSettingModel? UserRightsCreatePageFile { get; set; }

    [JsonPropertyName("userRightsCreatePermanentSharedObjects")]
    public DeviceManagementUserRightsSettingModel? UserRightsCreatePermanentSharedObjects { get; set; }

    [JsonPropertyName("userRightsCreateSymbolicLinks")]
    public DeviceManagementUserRightsSettingModel? UserRightsCreateSymbolicLinks { get; set; }

    [JsonPropertyName("userRightsCreateToken")]
    public DeviceManagementUserRightsSettingModel? UserRightsCreateToken { get; set; }

    [JsonPropertyName("userRightsDebugPrograms")]
    public DeviceManagementUserRightsSettingModel? UserRightsDebugPrograms { get; set; }

    [JsonPropertyName("userRightsDelegation")]
    public DeviceManagementUserRightsSettingModel? UserRightsDelegation { get; set; }

    [JsonPropertyName("userRightsDenyLocalLogOn")]
    public DeviceManagementUserRightsSettingModel? UserRightsDenyLocalLogOn { get; set; }

    [JsonPropertyName("userRightsGenerateSecurityAudits")]
    public DeviceManagementUserRightsSettingModel? UserRightsGenerateSecurityAudits { get; set; }

    [JsonPropertyName("userRightsImpersonateClient")]
    public DeviceManagementUserRightsSettingModel? UserRightsImpersonateClient { get; set; }

    [JsonPropertyName("userRightsIncreaseSchedulingPriority")]
    public DeviceManagementUserRightsSettingModel? UserRightsIncreaseSchedulingPriority { get; set; }

    [JsonPropertyName("userRightsLoadUnloadDrivers")]
    public DeviceManagementUserRightsSettingModel? UserRightsLoadUnloadDrivers { get; set; }

    [JsonPropertyName("userRightsLocalLogOn")]
    public DeviceManagementUserRightsSettingModel? UserRightsLocalLogOn { get; set; }

    [JsonPropertyName("userRightsLockMemory")]
    public DeviceManagementUserRightsSettingModel? UserRightsLockMemory { get; set; }

    [JsonPropertyName("userRightsManageAuditingAndSecurityLogs")]
    public DeviceManagementUserRightsSettingModel? UserRightsManageAuditingAndSecurityLogs { get; set; }

    [JsonPropertyName("userRightsManageVolumes")]
    public DeviceManagementUserRightsSettingModel? UserRightsManageVolumes { get; set; }

    [JsonPropertyName("userRightsModifyFirmwareEnvironment")]
    public DeviceManagementUserRightsSettingModel? UserRightsModifyFirmwareEnvironment { get; set; }

    [JsonPropertyName("userRightsModifyObjectLabels")]
    public DeviceManagementUserRightsSettingModel? UserRightsModifyObjectLabels { get; set; }

    [JsonPropertyName("userRightsProfileSingleProcess")]
    public DeviceManagementUserRightsSettingModel? UserRightsProfileSingleProcess { get; set; }

    [JsonPropertyName("userRightsRemoteDesktopServicesLogOn")]
    public DeviceManagementUserRightsSettingModel? UserRightsRemoteDesktopServicesLogOn { get; set; }

    [JsonPropertyName("userRightsRemoteShutdown")]
    public DeviceManagementUserRightsSettingModel? UserRightsRemoteShutdown { get; set; }

    [JsonPropertyName("userRightsRestoreData")]
    public DeviceManagementUserRightsSettingModel? UserRightsRestoreData { get; set; }

    [JsonPropertyName("userRightsTakeOwnership")]
    public DeviceManagementUserRightsSettingModel? UserRightsTakeOwnership { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("windowsDefenderTamperProtection")]
    public Windows10EndpointProtectionConfigurationWindowsDefenderTamperProtectionConstant? WindowsDefenderTamperProtection { get; set; }

    [JsonPropertyName("xboxServicesAccessoryManagementServiceStartupMode")]
    public Windows10EndpointProtectionConfigurationXboxServicesAccessoryManagementServiceStartupModeConstant? XboxServicesAccessoryManagementServiceStartupMode { get; set; }

    [JsonPropertyName("xboxServicesEnableXboxGameSaveTask")]
    public bool? XboxServicesEnableXboxGameSaveTask { get; set; }

    [JsonPropertyName("xboxServicesLiveAuthManagerServiceStartupMode")]
    public Windows10EndpointProtectionConfigurationXboxServicesLiveAuthManagerServiceStartupModeConstant? XboxServicesLiveAuthManagerServiceStartupMode { get; set; }

    [JsonPropertyName("xboxServicesLiveGameSaveServiceStartupMode")]
    public Windows10EndpointProtectionConfigurationXboxServicesLiveGameSaveServiceStartupModeConstant? XboxServicesLiveGameSaveServiceStartupMode { get; set; }

    [JsonPropertyName("xboxServicesLiveNetworkingServiceStartupMode")]
    public Windows10EndpointProtectionConfigurationXboxServicesLiveNetworkingServiceStartupModeConstant? XboxServicesLiveNetworkingServiceStartupMode { get; set; }
}
