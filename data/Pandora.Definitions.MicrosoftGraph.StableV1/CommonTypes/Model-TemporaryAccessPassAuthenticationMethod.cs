// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TemporaryAccessPassAuthenticationMethodModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isUsable")]
    public bool? IsUsable { get; set; }

    [JsonPropertyName("isUsableOnce")]
    public bool? IsUsableOnce { get; set; }

    [JsonPropertyName("lifetimeInMinutes")]
    public int? LifetimeInMinutes { get; set; }

    [JsonPropertyName("methodUsabilityReason")]
    public string? MethodUsabilityReason { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("temporaryAccessPass")]
    public string? TemporaryAccessPass { get; set; }
}
