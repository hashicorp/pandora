// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SynchronizationRuleModel
{
    [JsonPropertyName("containerFilter")]
    public ContainerFilterModel? ContainerFilter { get; set; }

    [JsonPropertyName("editable")]
    public bool? Editable { get; set; }

    [JsonPropertyName("groupFilter")]
    public GroupFilterModel? GroupFilter { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("metadata")]
    public List<StringKeyStringValuePairModel>? Metadata { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("objectMappings")]
    public List<ObjectMappingModel>? ObjectMappings { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("sourceDirectoryName")]
    public string? SourceDirectoryName { get; set; }

    [JsonPropertyName("targetDirectoryName")]
    public string? TargetDirectoryName { get; set; }
}
