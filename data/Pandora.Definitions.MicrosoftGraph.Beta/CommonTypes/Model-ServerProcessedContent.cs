// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServerProcessedContentModel
{
    [JsonPropertyName("componentDependencies")]
    public List<MetaDataKeyStringPairModel>? ComponentDependencies { get; set; }

    [JsonPropertyName("customMetadata")]
    public List<MetaDataKeyValuePairModel>? CustomMetadata { get; set; }

    [JsonPropertyName("htmlStrings")]
    public List<MetaDataKeyStringPairModel>? HtmlStrings { get; set; }

    [JsonPropertyName("imageSources")]
    public List<MetaDataKeyStringPairModel>? ImageSources { get; set; }

    [JsonPropertyName("links")]
    public List<MetaDataKeyStringPairModel>? Links { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("searchablePlainTexts")]
    public List<MetaDataKeyStringPairModel>? SearchablePlainTexts { get; set; }
}
