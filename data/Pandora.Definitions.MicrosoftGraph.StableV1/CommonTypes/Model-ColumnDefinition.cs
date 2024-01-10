// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ColumnDefinitionModel
{
    [JsonPropertyName("boolean")]
    public BooleanColumnModel? Boolean { get; set; }

    [JsonPropertyName("calculated")]
    public CalculatedColumnModel? Calculated { get; set; }

    [JsonPropertyName("choice")]
    public ChoiceColumnModel? Choice { get; set; }

    [JsonPropertyName("columnGroup")]
    public string? ColumnGroup { get; set; }

    [JsonPropertyName("contentApprovalStatus")]
    public ContentApprovalStatusColumnModel? ContentApprovalStatus { get; set; }

    [JsonPropertyName("currency")]
    public CurrencyColumnModel? Currency { get; set; }

    [JsonPropertyName("dateTime")]
    public DateTimeColumnModel? DateTime { get; set; }

    [JsonPropertyName("defaultValue")]
    public DefaultColumnValueModel? DefaultValue { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enforceUniqueValues")]
    public bool? EnforceUniqueValues { get; set; }

    [JsonPropertyName("geolocation")]
    public GeolocationColumnModel? Geolocation { get; set; }

    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    [JsonPropertyName("hyperlinkOrPicture")]
    public HyperlinkOrPictureColumnModel? HyperlinkOrPicture { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("indexed")]
    public bool? Indexed { get; set; }

    [JsonPropertyName("isDeletable")]
    public bool? IsDeletable { get; set; }

    [JsonPropertyName("isReorderable")]
    public bool? IsReorderable { get; set; }

    [JsonPropertyName("isSealed")]
    public bool? IsSealed { get; set; }

    [JsonPropertyName("lookup")]
    public LookupColumnModel? Lookup { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("number")]
    public NumberColumnModel? Number { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("personOrGroup")]
    public PersonOrGroupColumnModel? PersonOrGroup { get; set; }

    [JsonPropertyName("propagateChanges")]
    public bool? PropagateChanges { get; set; }

    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("sourceColumn")]
    public ColumnDefinitionModel? SourceColumn { get; set; }

    [JsonPropertyName("sourceContentType")]
    public ContentTypeInfoModel? SourceContentType { get; set; }

    [JsonPropertyName("term")]
    public TermColumnModel? Term { get; set; }

    [JsonPropertyName("text")]
    public TextColumnModel? Text { get; set; }

    [JsonPropertyName("thumbnail")]
    public ThumbnailColumnModel? Thumbnail { get; set; }

    [JsonPropertyName("type")]
    public ColumnDefinitionTypeConstant? Type { get; set; }

    [JsonPropertyName("validation")]
    public ColumnValidationModel? Validation { get; set; }
}
