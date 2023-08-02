// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsParticipantEndpointModel
{
    [JsonPropertyName("cpuCoresCount")]
    public int? CpuCoresCount { get; set; }

    [JsonPropertyName("cpuName")]
    public string? CpuName { get; set; }

    [JsonPropertyName("cpuProcessorSpeedInMhz")]
    public int? CpuProcessorSpeedInMhz { get; set; }

    [JsonPropertyName("feedback")]
    public UserFeedbackModel? Feedback { get; set; }

    [JsonPropertyName("identity")]
    public IdentitySetModel? Identity { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userAgent")]
    public UserAgentModel? UserAgent { get; set; }
}
