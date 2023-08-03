// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MicrosoftAuthenticatorAuthenticationMethodTargetModel
{
    [JsonPropertyName("authenticationMode")]
    public MicrosoftAuthenticatorAuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isRegistrationRequired")]
    public bool? IsRegistrationRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("targetType")]
    public AuthenticationMethodTargetTypeConstant? TargetType { get; set; }
}
