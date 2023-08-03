// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ApiApplicationModel
{
    [JsonPropertyName("acceptMappedClaims")]
    public bool? AcceptMappedClaims { get; set; }

    [JsonPropertyName("knownClientApplications")]
    public List<string>? KnownClientApplications { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oauth2PermissionScopes")]
    public List<PermissionScopeModel>? Oauth2PermissionScopes { get; set; }

    [JsonPropertyName("preAuthorizedApplications")]
    public List<PreAuthorizedApplicationModel>? PreAuthorizedApplications { get; set; }

    [JsonPropertyName("requestedAccessTokenVersion")]
    public int? RequestedAccessTokenVersion { get; set; }
}
