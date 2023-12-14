// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TitleAreaModel
{
    [JsonPropertyName("alternativeText")]
    public string? AlternativeText { get; set; }

    [JsonPropertyName("enableGradientEffect")]
    public bool? EnableGradientEffect { get; set; }

    [JsonPropertyName("imageWebUrl")]
    public string? ImageWebUrl { get; set; }

    [JsonPropertyName("layout")]
    public TitleAreaLayoutConstant? Layout { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serverProcessedContent")]
    public ServerProcessedContentModel? ServerProcessedContent { get; set; }

    [JsonPropertyName("showAuthor")]
    public bool? ShowAuthor { get; set; }

    [JsonPropertyName("showPublishedDate")]
    public bool? ShowPublishedDate { get; set; }

    [JsonPropertyName("showTextBlockAboveTitle")]
    public bool? ShowTextBlockAboveTitle { get; set; }

    [JsonPropertyName("textAboveTitle")]
    public string? TextAboveTitle { get; set; }

    [JsonPropertyName("textAlignment")]
    public TitleAreaTextAlignmentConstant? TextAlignment { get; set; }
}
