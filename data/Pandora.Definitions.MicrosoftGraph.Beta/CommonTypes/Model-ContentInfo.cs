// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ContentInfoModel
{
    [JsonPropertyName("format")]
    public ContentInfoFormatConstant? Format { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("metadata")]
    public List<KeyValuePairModel>? Metadata { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public ContentInfoStateConstant? State { get; set; }
}
