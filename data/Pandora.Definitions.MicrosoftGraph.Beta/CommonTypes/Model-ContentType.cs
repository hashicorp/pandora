// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ContentTypeModel
{
    [JsonPropertyName("associatedHubsUrls")]
    public List<string>? AssociatedHubsUrls { get; set; }

    [JsonPropertyName("base")]
    public ContentTypeModel? Base { get; set; }

    [JsonPropertyName("baseTypes")]
    public List<ContentTypeModel>? BaseTypes { get; set; }

    [JsonPropertyName("columnLinks")]
    public List<ColumnLinkModel>? ColumnLinks { get; set; }

    [JsonPropertyName("columnPositions")]
    public List<ColumnDefinitionModel>? ColumnPositions { get; set; }

    [JsonPropertyName("columns")]
    public List<ColumnDefinitionModel>? Columns { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("documentSet")]
    public DocumentSetModel? DocumentSet { get; set; }

    [JsonPropertyName("documentTemplate")]
    public DocumentSetContentModel? DocumentTemplate { get; set; }

    [JsonPropertyName("group")]
    public string? Group { get; set; }

    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inheritedFrom")]
    public ItemReferenceModel? InheritedFrom { get; set; }

    [JsonPropertyName("isBuiltIn")]
    public bool? IsBuiltIn { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("order")]
    public ContentTypeOrderModel? Order { get; set; }

    [JsonPropertyName("parentId")]
    public string? ParentId { get; set; }

    [JsonPropertyName("propagateChanges")]
    public bool? PropagateChanges { get; set; }

    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    [JsonPropertyName("sealed")]
    public bool? Sealed { get; set; }
}
