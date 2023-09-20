// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AudioConferencingModel
{
    [JsonPropertyName("conferenceId")]
    public string? ConferenceId { get; set; }

    [JsonPropertyName("dialinUrl")]
    public string? DialinUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tollFreeNumber")]
    public string? TollFreeNumber { get; set; }

    [JsonPropertyName("tollFreeNumbers")]
    public List<string>? TollFreeNumbers { get; set; }

    [JsonPropertyName("tollNumber")]
    public string? TollNumber { get; set; }

    [JsonPropertyName("tollNumbers")]
    public List<string>? TollNumbers { get; set; }
}
