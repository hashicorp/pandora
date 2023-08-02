// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WebPartDataModel
{
    [JsonPropertyName("audiences")]
    public List<string>? Audiences { get; set; }

    [JsonPropertyName("dataVersion")]
    public string? DataVersion { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("properties")]
    public JsonModel? Properties { get; set; }

    [JsonPropertyName("serverProcessedContent")]
    public ServerProcessedContentModel? ServerProcessedContent { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
