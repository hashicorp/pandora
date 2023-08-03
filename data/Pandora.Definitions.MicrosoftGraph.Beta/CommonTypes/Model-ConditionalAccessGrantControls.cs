// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConditionalAccessGrantControlsModel
{
    [JsonPropertyName("authenticationStrength")]
    public AuthenticationStrengthPolicyModel? AuthenticationStrength { get; set; }

    [JsonPropertyName("builtInControls")]
    public List<ConditionalAccessGrantControlConstant>? BuiltInControls { get; set; }

    [JsonPropertyName("customAuthenticationFactors")]
    public List<string>? CustomAuthenticationFactors { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operator")]
    public string? Operator { get; set; }

    [JsonPropertyName("termsOfUse")]
    public List<string>? TermsOfUse { get; set; }
}
