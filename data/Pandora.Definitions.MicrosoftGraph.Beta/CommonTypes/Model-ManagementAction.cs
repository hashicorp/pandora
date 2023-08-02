// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagementActionModel
{
    [JsonPropertyName("category")]
    public ManagementCategoryConstant? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("referenceTemplateId")]
    public string? ReferenceTemplateId { get; set; }

    [JsonPropertyName("referenceTemplateVersion")]
    public int? ReferenceTemplateVersion { get; set; }

    [JsonPropertyName("workloadActions")]
    public List<WorkloadActionModel>? WorkloadActions { get; set; }
}
