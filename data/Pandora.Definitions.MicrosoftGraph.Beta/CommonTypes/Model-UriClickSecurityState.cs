// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UriClickSecurityStateModel
{
    [JsonPropertyName("clickAction")]
    public string? ClickAction { get; set; }

    [JsonPropertyName("clickDateTime")]
    public DateTime? ClickDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sourceId")]
    public string? SourceId { get; set; }

    [JsonPropertyName("uriDomain")]
    public string? UriDomain { get; set; }

    [JsonPropertyName("verdict")]
    public string? Verdict { get; set; }
}
