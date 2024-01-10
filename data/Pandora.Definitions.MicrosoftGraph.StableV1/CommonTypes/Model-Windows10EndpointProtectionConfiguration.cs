// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class Windows10EndpointProtectionConfigurationModel
{
    [JsonPropertyName("appLockerApplicationControl")]
    public Windows10EndpointProtectionConfigurationAppLockerApplicationControlConstant? AppLockerApplicationControl { get; set; }

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

    [JsonPropertyName("applicationGuardBlockClipboardSharing")]
    public Windows10EndpointProtectionConfigurationApplicationGuardBlockClipboardSharingConstant? ApplicationGuardBlockClipboardSharing { get; set; }

    [JsonPropertyName("applicationGuardBlockFileTransfer")]
    public Windows10EndpointProtectionConfigurationApplicationGuardBlockFileTransferConstant? ApplicationGuardBlockFileTransfer { get; set; }

    [JsonPropertyName("applicationGuardBlockNonEnterpriseContent")]
    public bool? ApplicationGuardBlockNonEnterpriseContent { get; set; }

    [JsonPropertyName("applicationGuardEnabled")]
    public bool? ApplicationGuardEnabled { get; set; }

    [JsonPropertyName("applicationGuardForceAuditing")]
    public bool? ApplicationGuardForceAuditing { get; set; }

    [JsonPropertyName("assignments")]
    public List<DeviceConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("bitLockerDisableWarningForOtherDiskEncryption")]
    public bool? BitLockerDisableWarningForOtherDiskEncryption { get; set; }

    [JsonPropertyName("bitLockerEnableStorageCardEncryptionOnMobile")]
    public bool? BitLockerEnableStorageCardEncryptionOnMobile { get; set; }

    [JsonPropertyName("bitLockerEncryptDevice")]
    public bool? BitLockerEncryptDevice { get; set; }

    [JsonPropertyName("bitLockerRemovableDrivePolicy")]
    public BitLockerRemovableDrivePolicyModel? BitLockerRemovableDrivePolicy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defenderAdditionalGuardedFolders")]
    public List<string>? DefenderAdditionalGuardedFolders { get; set; }

    [JsonPropertyName("defenderAttackSurfaceReductionExcludedPaths")]
    public List<string>? DefenderAttackSurfaceReductionExcludedPaths { get; set; }

    [JsonPropertyName("defenderExploitProtectionXml")]
    public string? DefenderExploitProtectionXml { get; set; }

    [JsonPropertyName("defenderExploitProtectionXmlFileName")]
    public string? DefenderExploitProtectionXmlFileName { get; set; }

    [JsonPropertyName("defenderGuardedFoldersAllowedAppPaths")]
    public List<string>? DefenderGuardedFoldersAllowedAppPaths { get; set; }

    [JsonPropertyName("defenderSecurityCenterBlockExploitProtectionOverride")]
    public bool? DefenderSecurityCenterBlockExploitProtectionOverride { get; set; }

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

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("smartScreenBlockOverrideForFiles")]
    public bool? SmartScreenBlockOverrideForFiles { get; set; }

    [JsonPropertyName("smartScreenEnableInShell")]
    public bool? SmartScreenEnableInShell { get; set; }

    [JsonPropertyName("userStatusOverview")]
    public DeviceConfigurationUserOverviewModel? UserStatusOverview { get; set; }

    [JsonPropertyName("userStatuses")]
    public List<DeviceConfigurationUserStatusModel>? UserStatuses { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
