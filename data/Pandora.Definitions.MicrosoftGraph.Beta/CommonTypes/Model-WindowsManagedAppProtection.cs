// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsManagedAppProtectionModel
{
    [JsonPropertyName("allowedInboundDataTransferSources")]
    public WindowsManagedAppProtectionAllowedInboundDataTransferSourcesConstant? AllowedInboundDataTransferSources { get; set; }

    [JsonPropertyName("allowedOutboundClipboardSharingLevel")]
    public WindowsManagedAppProtectionAllowedOutboundClipboardSharingLevelConstant? AllowedOutboundClipboardSharingLevel { get; set; }

    [JsonPropertyName("allowedOutboundDataTransferDestinations")]
    public WindowsManagedAppProtectionAllowedOutboundDataTransferDestinationsConstant? AllowedOutboundDataTransferDestinations { get; set; }

    [JsonPropertyName("appActionIfUnableToAuthenticateUser")]
    public WindowsManagedAppProtectionAppActionIfUnableToAuthenticateUserConstant? AppActionIfUnableToAuthenticateUser { get; set; }

    [JsonPropertyName("apps")]
    public List<ManagedMobileAppModel>? Apps { get; set; }

    [JsonPropertyName("assignments")]
    public List<TargetedManagedAppPolicyAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deployedAppCount")]
    public int? DeployedAppCount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAssigned")]
    public bool? IsAssigned { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maximumAllowedDeviceThreatLevel")]
    public WindowsManagedAppProtectionMaximumAllowedDeviceThreatLevelConstant? MaximumAllowedDeviceThreatLevel { get; set; }

    [JsonPropertyName("maximumRequiredOsVersion")]
    public string? MaximumRequiredOsVersion { get; set; }

    [JsonPropertyName("maximumWarningOsVersion")]
    public string? MaximumWarningOsVersion { get; set; }

    [JsonPropertyName("maximumWipeOsVersion")]
    public string? MaximumWipeOsVersion { get; set; }

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

    [JsonPropertyName("minimumWipeAppVersion")]
    public string? MinimumWipeAppVersion { get; set; }

    [JsonPropertyName("minimumWipeOsVersion")]
    public string? MinimumWipeOsVersion { get; set; }

    [JsonPropertyName("minimumWipeSdkVersion")]
    public string? MinimumWipeSdkVersion { get; set; }

    [JsonPropertyName("mobileThreatDefenseRemediationAction")]
    public WindowsManagedAppProtectionMobileThreatDefenseRemediationActionConstant? MobileThreatDefenseRemediationAction { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("periodOfflineBeforeAccessCheck")]
    public string? PeriodOfflineBeforeAccessCheck { get; set; }

    [JsonPropertyName("periodOfflineBeforeWipeIsEnforced")]
    public string? PeriodOfflineBeforeWipeIsEnforced { get; set; }

    [JsonPropertyName("printBlocked")]
    public bool? PrintBlocked { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
