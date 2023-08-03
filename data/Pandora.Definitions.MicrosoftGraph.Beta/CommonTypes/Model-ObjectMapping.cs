// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ObjectMappingModel
{
    [JsonPropertyName("attributeMappings")]
    public List<AttributeMappingModel>? AttributeMappings { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("flowTypes")]
    public ObjectFlowTypesConstant? FlowTypes { get; set; }

    [JsonPropertyName("metadata")]
    public List<ObjectMappingMetadataEntryModel>? Metadata { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scope")]
    public FilterModel? Scope { get; set; }

    [JsonPropertyName("sourceObjectName")]
    public string? SourceObjectName { get; set; }

    [JsonPropertyName("targetObjectName")]
    public string? TargetObjectName { get; set; }
}
