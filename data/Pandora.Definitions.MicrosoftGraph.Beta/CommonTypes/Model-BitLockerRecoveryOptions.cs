// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BitLockerRecoveryOptionsModel
{
    [JsonPropertyName("blockDataRecoveryAgent")]
    public bool? BlockDataRecoveryAgent { get; set; }

    [JsonPropertyName("enableBitLockerAfterRecoveryInformationToStore")]
    public bool? EnableBitLockerAfterRecoveryInformationToStore { get; set; }

    [JsonPropertyName("enableRecoveryInformationSaveToStore")]
    public bool? EnableRecoveryInformationSaveToStore { get; set; }

    [JsonPropertyName("hideRecoveryOptions")]
    public bool? HideRecoveryOptions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recoveryInformationToStore")]
    public BitLockerRecoveryOptionsRecoveryInformationToStoreConstant? RecoveryInformationToStore { get; set; }

    [JsonPropertyName("recoveryKeyUsage")]
    public BitLockerRecoveryOptionsRecoveryKeyUsageConstant? RecoveryKeyUsage { get; set; }

    [JsonPropertyName("recoveryPasswordUsage")]
    public BitLockerRecoveryOptionsRecoveryPasswordUsageConstant? RecoveryPasswordUsage { get; set; }
}
