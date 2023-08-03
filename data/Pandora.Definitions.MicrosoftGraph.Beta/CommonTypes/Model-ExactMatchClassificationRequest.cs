// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExactMatchClassificationRequestModel
{
    [JsonPropertyName("contentClassifications")]
    public List<ContentClassificationModel>? ContentClassifications { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sensitiveTypeIds")]
    public List<string>? SensitiveTypeIds { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("timeoutInMs")]
    public int? TimeoutInMs { get; set; }
}
