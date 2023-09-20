// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsDeviceInfoModel
{
    [JsonPropertyName("captureDeviceDriver")]
    public string? CaptureDeviceDriver { get; set; }

    [JsonPropertyName("captureDeviceName")]
    public string? CaptureDeviceName { get; set; }

    [JsonPropertyName("howlingEventCount")]
    public int? HowlingEventCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("receivedNoiseLevel")]
    public int? ReceivedNoiseLevel { get; set; }

    [JsonPropertyName("receivedSignalLevel")]
    public int? ReceivedSignalLevel { get; set; }

    [JsonPropertyName("renderDeviceDriver")]
    public string? RenderDeviceDriver { get; set; }

    [JsonPropertyName("renderDeviceName")]
    public string? RenderDeviceName { get; set; }

    [JsonPropertyName("sentNoiseLevel")]
    public int? SentNoiseLevel { get; set; }

    [JsonPropertyName("sentSignalLevel")]
    public int? SentSignalLevel { get; set; }
}
