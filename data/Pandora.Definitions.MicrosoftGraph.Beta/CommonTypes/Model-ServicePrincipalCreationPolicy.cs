// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServicePrincipalCreationPolicyModel
{
    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("excludes")]
    public List<ServicePrincipalCreationConditionSetModel>? Excludes { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includes")]
    public List<ServicePrincipalCreationConditionSetModel>? Includes { get; set; }

    [JsonPropertyName("isBuiltIn")]
    public bool? IsBuiltIn { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
