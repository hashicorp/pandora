// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationStrengthRootModel
{
    [JsonPropertyName("authenticationCombinations")]
    public List<AuthenticationStrengthRootAuthenticationCombinationsConstant>? AuthenticationCombinations { get; set; }

    [JsonPropertyName("authenticationMethodModes")]
    public List<AuthenticationMethodModeDetailModel>? AuthenticationMethodModes { get; set; }

    [JsonPropertyName("combinations")]
    public List<AuthenticationStrengthRootCombinationsConstant>? Combinations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policies")]
    public List<AuthenticationStrengthPolicyModel>? Policies { get; set; }
}
