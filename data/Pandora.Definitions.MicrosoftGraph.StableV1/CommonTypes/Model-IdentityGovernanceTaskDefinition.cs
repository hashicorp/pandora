// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityGovernanceTaskDefinitionModel
{
    [JsonPropertyName("category")]
    public IdentityGovernanceTaskDefinitionCategoryConstant? Category { get; set; }

    [JsonPropertyName("continueOnError")]
    public bool? ContinueOnError { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parameters")]
    public List<IdentityGovernanceParameterModel>? Parameters { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
