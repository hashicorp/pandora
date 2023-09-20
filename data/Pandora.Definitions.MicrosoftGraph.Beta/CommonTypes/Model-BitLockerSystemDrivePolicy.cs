// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BitLockerSystemDrivePolicyModel
{
    [JsonPropertyName("encryptionMethod")]
    public BitLockerSystemDrivePolicyEncryptionMethodConstant? EncryptionMethod { get; set; }

    [JsonPropertyName("minimumPinLength")]
    public int? MinimumPinLength { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("prebootRecoveryEnableMessageAndUrl")]
    public bool? PrebootRecoveryEnableMessageAndUrl { get; set; }

    [JsonPropertyName("prebootRecoveryMessage")]
    public string? PrebootRecoveryMessage { get; set; }

    [JsonPropertyName("prebootRecoveryUrl")]
    public string? PrebootRecoveryUrl { get; set; }

    [JsonPropertyName("recoveryOptions")]
    public BitLockerRecoveryOptionsModel? RecoveryOptions { get; set; }

    [JsonPropertyName("startupAuthenticationBlockWithoutTpmChip")]
    public bool? StartupAuthenticationBlockWithoutTpmChip { get; set; }

    [JsonPropertyName("startupAuthenticationRequired")]
    public bool? StartupAuthenticationRequired { get; set; }

    [JsonPropertyName("startupAuthenticationTpmKeyUsage")]
    public BitLockerSystemDrivePolicyStartupAuthenticationTpmKeyUsageConstant? StartupAuthenticationTpmKeyUsage { get; set; }

    [JsonPropertyName("startupAuthenticationTpmPinAndKeyUsage")]
    public BitLockerSystemDrivePolicyStartupAuthenticationTpmPinAndKeyUsageConstant? StartupAuthenticationTpmPinAndKeyUsage { get; set; }

    [JsonPropertyName("startupAuthenticationTpmPinUsage")]
    public BitLockerSystemDrivePolicyStartupAuthenticationTpmPinUsageConstant? StartupAuthenticationTpmPinUsage { get; set; }

    [JsonPropertyName("startupAuthenticationTpmUsage")]
    public BitLockerSystemDrivePolicyStartupAuthenticationTpmUsageConstant? StartupAuthenticationTpmUsage { get; set; }
}
