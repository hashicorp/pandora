// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AttributeDefinitionModel
{
    [JsonPropertyName("anchor")]
    public bool? Anchor { get; set; }

    [JsonPropertyName("apiExpressions")]
    public List<StringKeyStringValuePairModel>? ApiExpressions { get; set; }

    [JsonPropertyName("caseExact")]
    public bool? CaseExact { get; set; }

    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; set; }

    [JsonPropertyName("flowNullValues")]
    public bool? FlowNullValues { get; set; }

    [JsonPropertyName("metadata")]
    public List<AttributeDefinitionMetadataEntryModel>? Metadata { get; set; }

    [JsonPropertyName("multivalued")]
    public bool? Multivalued { get; set; }

    [JsonPropertyName("mutability")]
    public AttributeDefinitionMutabilityConstant? Mutability { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("referencedObjects")]
    public List<ReferencedObjectModel>? ReferencedObjects { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("type")]
    public AttributeDefinitionTypeConstant? Type { get; set; }
}
