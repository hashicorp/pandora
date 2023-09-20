// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConditionalAccessRootModel
{
    [JsonPropertyName("authenticationContextClassReferences")]
    public List<AuthenticationContextClassReferenceModel>? AuthenticationContextClassReferences { get; set; }

    [JsonPropertyName("authenticationStrength")]
    public AuthenticationStrengthRootModel? AuthenticationStrength { get; set; }

    [JsonPropertyName("authenticationStrengths")]
    public AuthenticationStrengthRootModel? AuthenticationStrengths { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("namedLocations")]
    public List<NamedLocationModel>? NamedLocations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policies")]
    public List<ConditionalAccessPolicyModel>? Policies { get; set; }

    [JsonPropertyName("templates")]
    public List<ConditionalAccessTemplateModel>? Templates { get; set; }
}
