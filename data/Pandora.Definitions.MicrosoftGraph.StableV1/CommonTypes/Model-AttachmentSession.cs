// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AttachmentSessionModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("nextExpectedRanges")]
    public List<string>? NextExpectedRanges { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
