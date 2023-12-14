// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AttributeMappingModel
{
    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; set; }

    [JsonPropertyName("exportMissingReferences")]
    public bool? ExportMissingReferences { get; set; }

    [JsonPropertyName("flowBehavior")]
    public AttributeMappingFlowBehaviorConstant? FlowBehavior { get; set; }

    [JsonPropertyName("flowType")]
    public AttributeMappingFlowTypeConstant? FlowType { get; set; }

    [JsonPropertyName("matchingPriority")]
    public int? MatchingPriority { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("source")]
    public AttributeMappingSourceModel? Source { get; set; }

    [JsonPropertyName("targetAttributeName")]
    public string? TargetAttributeName { get; set; }
}
