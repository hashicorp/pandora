// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TargetedManagedAppProtectionModel
{
    [JsonPropertyName("allowedDataIngestionLocations")]
    public List<ManagedAppDataIngestionLocationConstant>? AllowedDataIngestionLocations { get; set; }

    [JsonPropertyName("allowedDataStorageLocations")]
    public List<ManagedAppDataStorageLocationConstant>? AllowedDataStorageLocations { get; set; }

    [JsonPropertyName("allowedInboundDataTransferSources")]
    public ManagedAppDataTransferLevelConstant? AllowedInboundDataTransferSources { get; set; }

    [JsonPropertyName("allowedOutboundClipboardSharingExceptionLength")]
    public int? AllowedOutboundClipboardSharingExceptionLength { get; set; }

    [JsonPropertyName("allowedOutboundClipboardSharingLevel")]
    public ManagedAppClipboardSharingLevelConstant? AllowedOutboundClipboardSharingLevel { get; set; }

    [JsonPropertyName("allowedOutboundDataTransferDestinations")]
    public ManagedAppDataTransferLevelConstant? AllowedOutboundDataTransferDestinations { get; set; }

    [JsonPropertyName("appActionIfDeviceComplianceRequired")]
    public ManagedAppRemediationActionConstant? AppActionIfDeviceComplianceRequired { get; set; }

    [JsonPropertyName("appActionIfMaximumPinRetriesExceeded")]
    public ManagedAppRemediationActionConstant? AppActionIfMaximumPinRetriesExceeded { get; set; }

    [JsonPropertyName("appActionIfUnableToAuthenticateUser")]
    public ManagedAppRemediationActionConstant? AppActionIfUnableToAuthenticateUser { get; set; }

    [JsonPropertyName("appGroupType")]
    public TargetedManagedAppGroupTypeConstant? AppGroupType { get; set; }

    [JsonPropertyName("assignments")]
    public List<TargetedManagedAppPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("blockDataIngestionIntoOrganizationDocuments")]
    public bool? BlockDataIngestionIntoOrganizationDocuments { get; set; }

    [JsonPropertyName("contactSyncBlocked")]
    public bool? ContactSyncBlocked { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dataBackupBlocked")]
    public bool? DataBackupBlocked { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceComplianceRequired")]
    public bool? DeviceComplianceRequired { get; set; }

    [JsonPropertyName("dialerRestrictionLevel")]
    public ManagedAppPhoneNumberRedirectLevelConstant? DialerRestrictionLevel { get; set; }

    [JsonPropertyName("disableAppPinIfDevicePinIsSet")]
    public bool? DisableAppPinIfDevicePinIsSet { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fingerprintBlocked")]
    public bool? FingerprintBlocked { get; set; }

    [JsonPropertyName("gracePeriodToBlockAppsDuringOffClockHours")]
    public string? GracePeriodToBlockAppsDuringOffClockHours { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("managedBrowser")]
    public ManagedBrowserTypeConstant? ManagedBrowser { get; set; }

    [JsonPropertyName("managedBrowserToOpenLinksRequired")]
    public bool? ManagedBrowserToOpenLinksRequired { get; set; }

    [JsonPropertyName("maximumAllowedDeviceThreatLevel")]
    public ManagedAppDeviceThreatLevelConstant? MaximumAllowedDeviceThreatLevel { get; set; }

    [JsonPropertyName("maximumPinRetries")]
    public int? MaximumPinRetries { get; set; }

    [JsonPropertyName("maximumRequiredOsVersion")]
    public string? MaximumRequiredOsVersion { get; set; }

    [JsonPropertyName("maximumWarningOsVersion")]
    public string? MaximumWarningOsVersion { get; set; }

    [JsonPropertyName("maximumWipeOsVersion")]
    public string? MaximumWipeOsVersion { get; set; }

    [JsonPropertyName("minimumPinLength")]
    public int? MinimumPinLength { get; set; }

    [JsonPropertyName("minimumRequiredAppVersion")]
    public string? MinimumRequiredAppVersion { get; set; }

    [JsonPropertyName("minimumRequiredOsVersion")]
    public string? MinimumRequiredOsVersion { get; set; }

    [JsonPropertyName("minimumWarningAppVersion")]
    public string? MinimumWarningAppVersion { get; set; }

    [JsonPropertyName("minimumWarningOsVersion")]
    public string? MinimumWarningOsVersion { get; set; }

    [JsonPropertyName("minimumWipeAppVersion")]
    public string? MinimumWipeAppVersion { get; set; }

    [JsonPropertyName("minimumWipeOsVersion")]
    public string? MinimumWipeOsVersion { get; set; }

    [JsonPropertyName("mobileThreatDefensePartnerPriority")]
    public MobileThreatDefensePartnerPriorityConstant? MobileThreatDefensePartnerPriority { get; set; }

    [JsonPropertyName("mobileThreatDefenseRemediationAction")]
    public ManagedAppRemediationActionConstant? MobileThreatDefenseRemediationAction { get; set; }

    [JsonPropertyName("notificationRestriction")]
    public ManagedAppNotificationRestrictionConstant? NotificationRestriction { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizationalCredentialsRequired")]
    public bool? OrganizationalCredentialsRequired { get; set; }

    [JsonPropertyName("periodBeforePinReset")]
    public string? PeriodBeforePinReset { get; set; }

    [JsonPropertyName("periodOfflineBeforeAccessCheck")]
    public string? PeriodOfflineBeforeAccessCheck { get; set; }

    [JsonPropertyName("periodOfflineBeforeWipeIsEnforced")]
    public string? PeriodOfflineBeforeWipeIsEnforced { get; set; }

    [JsonPropertyName("periodOnlineBeforeAccessCheck")]
    public string? PeriodOnlineBeforeAccessCheck { get; set; }

    [JsonPropertyName("pinCharacterSet")]
    public ManagedAppPinCharacterSetConstant? PinCharacterSet { get; set; }

    [JsonPropertyName("pinRequired")]
    public bool? PinRequired { get; set; }

    [JsonPropertyName("pinRequiredInsteadOfBiometricTimeout")]
    public string? PinRequiredInsteadOfBiometricTimeout { get; set; }

    [JsonPropertyName("previousPinBlockCount")]
    public int? PreviousPinBlockCount { get; set; }

    [JsonPropertyName("printBlocked")]
    public bool? PrintBlocked { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("saveAsBlocked")]
    public bool? SaveAsBlocked { get; set; }

    [JsonPropertyName("simplePinBlocked")]
    public bool? SimplePinBlocked { get; set; }

    [JsonPropertyName("targetedAppManagementLevels")]
    public AppManagementLevelConstant? TargetedAppManagementLevels { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
