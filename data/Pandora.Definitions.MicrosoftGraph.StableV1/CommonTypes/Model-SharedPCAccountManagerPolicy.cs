// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SharedPCAccountManagerPolicyModel
{
    [JsonPropertyName("accountDeletionPolicy")]
    public SharedPCAccountDeletionPolicyTypeConstant? AccountDeletionPolicy { get; set; }

    [JsonPropertyName("cacheAccountsAboveDiskFreePercentage")]
    public int? CacheAccountsAboveDiskFreePercentage { get; set; }

    [JsonPropertyName("inactiveThresholdDays")]
    public int? InactiveThresholdDays { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("removeAccountsBelowDiskFreePercentage")]
    public int? RemoveAccountsBelowDiskFreePercentage { get; set; }
}
