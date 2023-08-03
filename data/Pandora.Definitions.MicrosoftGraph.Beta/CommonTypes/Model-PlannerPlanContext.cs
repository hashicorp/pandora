// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerPlanContextModel
{
    [JsonPropertyName("associationType")]
    public string? AssociationType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayNameSegments")]
    public List<string>? DisplayNameSegments { get; set; }

    [JsonPropertyName("isCreationContext")]
    public bool? IsCreationContext { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ownerAppId")]
    public string? OwnerAppId { get; set; }
}
