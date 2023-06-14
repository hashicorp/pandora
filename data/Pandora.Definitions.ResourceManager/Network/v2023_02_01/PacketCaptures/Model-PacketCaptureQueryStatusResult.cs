using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.PacketCaptures;


internal class PacketCaptureQueryStatusResultModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("captureStartTime")]
    public DateTime? CaptureStartTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("packetCaptureError")]
    public List<PcErrorConstant>? PacketCaptureError { get; set; }

    [JsonPropertyName("packetCaptureStatus")]
    public PcStatusConstant? PacketCaptureStatus { get; set; }

    [JsonPropertyName("stopReason")]
    public string? StopReason { get; set; }
}
