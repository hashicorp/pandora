// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BitLockerFixedDrivePolicyModel
{
    [JsonPropertyName("encryptionMethod")]
    public BitLockerFixedDrivePolicyEncryptionMethodConstant? EncryptionMethod { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recoveryOptions")]
    public BitLockerRecoveryOptionsModel? RecoveryOptions { get; set; }

    [JsonPropertyName("requireEncryptionForWriteAccess")]
    public bool? RequireEncryptionForWriteAccess { get; set; }
}
