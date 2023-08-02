// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PowerliftIncidentMetadataModel
{
    [JsonPropertyName("application")]
    public string? Application { get; set; }

    [JsonPropertyName("clientVersion")]
    public string? ClientVersion { get; set; }

    [JsonPropertyName("createdAtDateTime")]
    public DateTime? CreatedAtDateTime { get; set; }

    [JsonPropertyName("easyId")]
    public string? EasyId { get; set; }

    [JsonPropertyName("fileNames")]
    public List<string>? FileNames { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public string? Platform { get; set; }

    [JsonPropertyName("powerliftId")]
    public string? PowerliftId { get; set; }
}
