// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TextClassificationRequestModel
{
    [JsonPropertyName("contentMetaData")]
    public ClassificationRequestContentMetaDataModel? ContentMetaData { get; set; }

    [JsonPropertyName("fileExtension")]
    public string? FileExtension { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("matchTolerancesToInclude")]
    public TextClassificationRequestMatchTolerancesToIncludeConstant? MatchTolerancesToInclude { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scopesToRun")]
    public TextClassificationRequestScopesToRunConstant? ScopesToRun { get; set; }

    [JsonPropertyName("sensitiveTypeIds")]
    public List<string>? SensitiveTypeIds { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
