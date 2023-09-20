// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationStrengthModel
{
    [JsonPropertyName("authenticationStrengthId")]
    public string? AuthenticationStrengthId { get; set; }

    [JsonPropertyName("authenticationStrengthResult")]
    public AuthenticationStrengthAuthenticationStrengthResultConstant? AuthenticationStrengthResult { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
