// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class OnlineMeetingInfoModel
{
    [JsonPropertyName("conferenceId")]
    public string? ConferenceId { get; set; }

    [JsonPropertyName("joinUrl")]
    public string? JoinUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("phones")]
    public List<PhoneModel>? Phones { get; set; }

    [JsonPropertyName("quickDial")]
    public string? QuickDial { get; set; }

    [JsonPropertyName("tollFreeNumbers")]
    public List<string>? TollFreeNumbers { get; set; }

    [JsonPropertyName("tollNumber")]
    public string? TollNumber { get; set; }
}
