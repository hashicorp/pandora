// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AzureAdJoinPolicyModel
{
    [JsonPropertyName("allowedGroups")]
    public List<string>? AllowedGroups { get; set; }

    [JsonPropertyName("allowedUsers")]
    public List<string>? AllowedUsers { get; set; }

    [JsonPropertyName("appliesTo")]
    public PolicyScopeConstant? AppliesTo { get; set; }

    [JsonPropertyName("isAdminConfigurable")]
    public bool? IsAdminConfigurable { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
