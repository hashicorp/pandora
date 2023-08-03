// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudCommunicationsModel
{
    [JsonPropertyName("callRecords")]
    public List<CallRecordModel>? CallRecords { get; set; }

    [JsonPropertyName("calls")]
    public List<CallModel>? Calls { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onlineMeetings")]
    public List<OnlineMeetingModel>? OnlineMeetings { get; set; }

    [JsonPropertyName("presences")]
    public List<PresenceModel>? Presences { get; set; }
}
