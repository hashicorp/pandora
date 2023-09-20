// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SharedAppleDeviceUserModel
{
    [JsonPropertyName("dataQuota")]
    public int? DataQuota { get; set; }

    [JsonPropertyName("dataToSync")]
    public bool? DataToSync { get; set; }

    [JsonPropertyName("dataUsed")]
    public int? DataUsed { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
