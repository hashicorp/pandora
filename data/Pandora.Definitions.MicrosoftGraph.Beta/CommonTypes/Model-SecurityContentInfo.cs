// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityContentInfoModel
{
    [JsonPropertyName("contentFormat")]
    public string? ContentFormat { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("metadata")]
    public List<SecurityKeyValuePairModel>? Metadata { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public SecurityContentInfoStateConstant? State { get; set; }
}
