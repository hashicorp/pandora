// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DeviceHealthAttestationStateModel
{
    [JsonPropertyName("attestationIdentityKey")]
    public string? AttestationIdentityKey { get; set; }

    [JsonPropertyName("bitLockerStatus")]
    public string? BitLockerStatus { get; set; }

    [JsonPropertyName("bootAppSecurityVersion")]
    public string? BootAppSecurityVersion { get; set; }

    [JsonPropertyName("bootDebugging")]
    public string? BootDebugging { get; set; }

    [JsonPropertyName("bootManagerSecurityVersion")]
    public string? BootManagerSecurityVersion { get; set; }

    [JsonPropertyName("bootManagerVersion")]
    public string? BootManagerVersion { get; set; }

    [JsonPropertyName("bootRevisionListInfo")]
    public string? BootRevisionListInfo { get; set; }

    [JsonPropertyName("codeIntegrity")]
    public string? CodeIntegrity { get; set; }

    [JsonPropertyName("codeIntegrityCheckVersion")]
    public string? CodeIntegrityCheckVersion { get; set; }

    [JsonPropertyName("codeIntegrityPolicy")]
    public string? CodeIntegrityPolicy { get; set; }

    [JsonPropertyName("contentNamespaceUrl")]
    public string? ContentNamespaceUrl { get; set; }

    [JsonPropertyName("contentVersion")]
    public string? ContentVersion { get; set; }

    [JsonPropertyName("dataExcutionPolicy")]
    public string? DataExcutionPolicy { get; set; }

    [JsonPropertyName("deviceHealthAttestationStatus")]
    public string? DeviceHealthAttestationStatus { get; set; }

    [JsonPropertyName("earlyLaunchAntiMalwareDriverProtection")]
    public string? EarlyLaunchAntiMalwareDriverProtection { get; set; }

    [JsonPropertyName("healthAttestationSupportedStatus")]
    public string? HealthAttestationSupportedStatus { get; set; }

    [JsonPropertyName("healthStatusMismatchInfo")]
    public string? HealthStatusMismatchInfo { get; set; }

    [JsonPropertyName("issuedDateTime")]
    public DateTime? IssuedDateTime { get; set; }

    [JsonPropertyName("lastUpdateDateTime")]
    public string? LastUpdateDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystemKernelDebugging")]
    public string? OperatingSystemKernelDebugging { get; set; }

    [JsonPropertyName("operatingSystemRevListInfo")]
    public string? OperatingSystemRevListInfo { get; set; }

    [JsonPropertyName("pcr0")]
    public string? Pcr0 { get; set; }

    [JsonPropertyName("pcrHashAlgorithm")]
    public string? PcrHashAlgorithm { get; set; }

    [JsonPropertyName("resetCount")]
    public long? ResetCount { get; set; }

    [JsonPropertyName("restartCount")]
    public long? RestartCount { get; set; }

    [JsonPropertyName("safeMode")]
    public string? SafeMode { get; set; }

    [JsonPropertyName("secureBoot")]
    public string? SecureBoot { get; set; }

    [JsonPropertyName("secureBootConfigurationPolicyFingerPrint")]
    public string? SecureBootConfigurationPolicyFingerPrint { get; set; }

    [JsonPropertyName("testSigning")]
    public string? TestSigning { get; set; }

    [JsonPropertyName("tpmVersion")]
    public string? TpmVersion { get; set; }

    [JsonPropertyName("virtualSecureMode")]
    public string? VirtualSecureMode { get; set; }

    [JsonPropertyName("windowsPE")]
    public string? WindowsPE { get; set; }
}
