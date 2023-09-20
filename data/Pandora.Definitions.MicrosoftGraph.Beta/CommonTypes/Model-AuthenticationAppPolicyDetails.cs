// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationAppPolicyDetailsModel
{
    [JsonPropertyName("adminConfiguration")]
    public AuthenticationAppPolicyDetailsAdminConfigurationConstant? AdminConfiguration { get; set; }

    [JsonPropertyName("authenticationEvaluation")]
    public AuthenticationAppPolicyDetailsAuthenticationEvaluationConstant? AuthenticationEvaluation { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("status")]
    public AuthenticationAppPolicyDetailsStatusConstant? Status { get; set; }
}
