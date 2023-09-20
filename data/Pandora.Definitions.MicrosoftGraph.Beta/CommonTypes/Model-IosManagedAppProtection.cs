// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosManagedAppProtectionModel
{
    [JsonPropertyName("allowedDataIngestionLocations")]
    public List<IosManagedAppProtectionAllowedDataIngestionLocationsConstant>? AllowedDataIngestionLocations { get; set; }

    [JsonPropertyName("allowedDataStorageLocations")]
    public List<IosManagedAppProtectionAllowedDataStorageLocationsConstant>? AllowedDataStorageLocations { get; set; }

    [JsonPropertyName("allowedInboundDataTransferSources")]
    public IosManagedAppProtectionAllowedInboundDataTransferSourcesConstant? AllowedInboundDataTransferSources { get; set; }

    [JsonPropertyName("allowedIosDeviceModels")]
    public string? AllowedIosDeviceModels { get; set; }

    [JsonPropertyName("allowedOutboundClipboardSharingExceptionLength")]
    public int? AllowedOutboundClipboardSharingExceptionLength { get; set; }

    [JsonPropertyName("allowedOutboundClipboardSharingLevel")]
    public IosManagedAppProtectionAllowedOutboundClipboardSharingLevelConstant? AllowedOutboundClipboardSharingLevel { get; set; }

    [JsonPropertyName("allowedOutboundDataTransferDestinations")]
    public IosManagedAppProtectionAllowedOutboundDataTransferDestinationsConstant? AllowedOutboundDataTransferDestinations { get; set; }

    [JsonPropertyName("appActionIfDeviceComplianceRequired")]
    public IosManagedAppProtectionAppActionIfDeviceComplianceRequiredConstant? AppActionIfDeviceComplianceRequired { get; set; }

    [JsonPropertyName("appActionIfIosDeviceModelNotAllowed")]
    public IosManagedAppProtectionAppActionIfIosDeviceModelNotAllowedConstant? AppActionIfIosDeviceModelNotAllowed { get; set; }

    [JsonPropertyName("appActionIfMaximumPinRetriesExceeded")]
    public IosManagedAppProtectionAppActionIfMaximumPinRetriesExceededConstant? AppActionIfMaximumPinRetriesExceeded { get; set; }

    [JsonPropertyName("appActionIfUnableToAuthenticateUser")]
    public IosManagedAppProtectionAppActionIfUnableToAuthenticateUserConstant? AppActionIfUnableToAuthenticateUser { get; set; }

    [JsonPropertyName("appDataEncryptionType")]
    public IosManagedAppProtectionAppDataEncryptionTypeConstant? AppDataEncryptionType { get; set; }

    [JsonPropertyName("appGroupType")]
    public IosManagedAppProtectionAppGroupTypeConstant? AppGroupType { get; set; }

    [JsonPropertyName("apps")]
    public List<ManagedMobileAppModel>? Apps { get; set; }

    [JsonPropertyName("assignments")]
    public List<TargetedManagedAppPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("blockDataIngestionIntoOrganizationDocuments")]
    public bool? BlockDataIngestionIntoOrganizationDocuments { get; set; }

    [JsonPropertyName("contactSyncBlocked")]
    public bool? ContactSyncBlocked { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customBrowserProtocol")]
    public string? CustomBrowserProtocol { get; set; }

    [JsonPropertyName("customDialerAppProtocol")]
    public string? CustomDialerAppProtocol { get; set; }

    [JsonPropertyName("dataBackupBlocked")]
    public bool? DataBackupBlocked { get; set; }

    [JsonPropertyName("deployedAppCount")]
    public int? DeployedAppCount { get; set; }

    [JsonPropertyName("deploymentSummary")]
    public ManagedAppPolicyDeploymentSummaryModel? DeploymentSummary { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceComplianceRequired")]
    public bool? DeviceComplianceRequired { get; set; }

    [JsonPropertyName("dialerRestrictionLevel")]
    public IosManagedAppProtectionDialerRestrictionLevelConstant? DialerRestrictionLevel { get; set; }

    [JsonPropertyName("disableAppPinIfDevicePinIsSet")]
    public bool? DisableAppPinIfDevicePinIsSet { get; set; }

    [JsonPropertyName("disableProtectionOfManagedOutboundOpenInData")]
    public bool? DisableProtectionOfManagedOutboundOpenInData { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("exemptedAppProtocols")]
    public List<KeyValuePairModel>? ExemptedAppProtocols { get; set; }

    [JsonPropertyName("exemptedUniversalLinks")]
    public List<string>? ExemptedUniversalLinks { get; set; }

    [JsonPropertyName("faceIdBlocked")]
    public bool? FaceIdBlocked { get; set; }

    [JsonPropertyName("filterOpenInToOnlyManagedApps")]
    public bool? FilterOpenInToOnlyManagedApps { get; set; }

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
    public IosManagedAppProtectionManagedBrowserConstant? ManagedBrowser { get; set; }

    [JsonPropertyName("managedBrowserToOpenLinksRequired")]
    public bool? ManagedBrowserToOpenLinksRequired { get; set; }

    [JsonPropertyName("managedUniversalLinks")]
    public List<string>? ManagedUniversalLinks { get; set; }

    [JsonPropertyName("maximumAllowedDeviceThreatLevel")]
    public IosManagedAppProtectionMaximumAllowedDeviceThreatLevelConstant? MaximumAllowedDeviceThreatLevel { get; set; }

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

    [JsonPropertyName("minimumRequiredSdkVersion")]
    public string? MinimumRequiredSdkVersion { get; set; }

    [JsonPropertyName("minimumWarningAppVersion")]
    public string? MinimumWarningAppVersion { get; set; }

    [JsonPropertyName("minimumWarningOsVersion")]
    public string? MinimumWarningOsVersion { get; set; }

    [JsonPropertyName("minimumWarningSdkVersion")]
    public string? MinimumWarningSdkVersion { get; set; }

    [JsonPropertyName("minimumWipeAppVersion")]
    public string? MinimumWipeAppVersion { get; set; }

    [JsonPropertyName("minimumWipeOsVersion")]
    public string? MinimumWipeOsVersion { get; set; }

    [JsonPropertyName("minimumWipeSdkVersion")]
    public string? MinimumWipeSdkVersion { get; set; }

    [JsonPropertyName("mobileThreatDefensePartnerPriority")]
    public IosManagedAppProtectionMobileThreatDefensePartnerPriorityConstant? MobileThreatDefensePartnerPriority { get; set; }

    [JsonPropertyName("mobileThreatDefenseRemediationAction")]
    public IosManagedAppProtectionMobileThreatDefenseRemediationActionConstant? MobileThreatDefenseRemediationAction { get; set; }

    [JsonPropertyName("notificationRestriction")]
    public IosManagedAppProtectionNotificationRestrictionConstant? NotificationRestriction { get; set; }

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
    public IosManagedAppProtectionPinCharacterSetConstant? PinCharacterSet { get; set; }

    [JsonPropertyName("pinRequired")]
    public bool? PinRequired { get; set; }

    [JsonPropertyName("pinRequiredInsteadOfBiometricTimeout")]
    public string? PinRequiredInsteadOfBiometricTimeout { get; set; }

    [JsonPropertyName("previousPinBlockCount")]
    public int? PreviousPinBlockCount { get; set; }

    [JsonPropertyName("printBlocked")]
    public bool? PrintBlocked { get; set; }

    [JsonPropertyName("protectInboundDataFromUnknownSources")]
    public bool? ProtectInboundDataFromUnknownSources { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("saveAsBlocked")]
    public bool? SaveAsBlocked { get; set; }

    [JsonPropertyName("simplePinBlocked")]
    public bool? SimplePinBlocked { get; set; }

    [JsonPropertyName("targetedAppManagementLevels")]
    public IosManagedAppProtectionTargetedAppManagementLevelsConstant? TargetedAppManagementLevels { get; set; }

    [JsonPropertyName("thirdPartyKeyboardsBlocked")]
    public bool? ThirdPartyKeyboardsBlocked { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
