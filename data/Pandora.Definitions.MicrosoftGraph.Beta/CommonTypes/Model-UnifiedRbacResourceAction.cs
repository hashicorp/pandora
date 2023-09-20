// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRbacResourceActionModel
{
    [JsonPropertyName("actionVerb")]
    public string? ActionVerb { get; set; }

    [JsonPropertyName("authenticationContext")]
    public AuthenticationContextClassReferenceModel? AuthenticationContext { get; set; }

    [JsonPropertyName("authenticationContextId")]
    public string? AuthenticationContextId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAuthenticationContextSettable")]
    public bool? IsAuthenticationContextSettable { get; set; }

    [JsonPropertyName("isPrivileged")]
    public bool? IsPrivileged { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceScope")]
    public UnifiedRbacResourceScopeModel? ResourceScope { get; set; }

    [JsonPropertyName("resourceScopeId")]
    public string? ResourceScopeId { get; set; }
}
