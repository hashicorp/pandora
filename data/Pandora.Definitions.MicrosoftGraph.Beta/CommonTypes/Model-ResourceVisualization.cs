// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ResourceVisualizationModel
{
    [JsonPropertyName("containerDisplayName")]
    public string? ContainerDisplayName { get; set; }

    [JsonPropertyName("containerType")]
    public string? ContainerType { get; set; }

    [JsonPropertyName("containerWebUrl")]
    public string? ContainerWebUrl { get; set; }

    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("previewImageUrl")]
    public string? PreviewImageUrl { get; set; }

    [JsonPropertyName("previewText")]
    public string? PreviewText { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
