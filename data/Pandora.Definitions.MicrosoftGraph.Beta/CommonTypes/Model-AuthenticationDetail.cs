// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationDetailModel
{
    [JsonPropertyName("authenticationMethod")]
    public string? AuthenticationMethod { get; set; }

    [JsonPropertyName("authenticationMethodDetail")]
    public string? AuthenticationMethodDetail { get; set; }

    [JsonPropertyName("authenticationStepDateTime")]
    public DateTime? AuthenticationStepDateTime { get; set; }

    [JsonPropertyName("authenticationStepRequirement")]
    public string? AuthenticationStepRequirement { get; set; }

    [JsonPropertyName("authenticationStepResultDetail")]
    public string? AuthenticationStepResultDetail { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("succeeded")]
    public bool? Succeeded { get; set; }
}
