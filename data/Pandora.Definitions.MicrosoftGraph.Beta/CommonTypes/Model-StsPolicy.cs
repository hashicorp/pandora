// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class StsPolicyModel
{
    [JsonPropertyName("appliesTo")]
    public List<DirectoryObjectModel>? AppliesTo { get; set; }

    [JsonPropertyName("definition")]
    public List<string>? Definition { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isOrganizationDefault")]
    public bool? IsOrganizationDefault { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
