using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCaptures;


internal class PacketCapturePropertiesFormatModel
{
    [JsonPropertyName("bytesToCapturePerPacket")]
    public int? BytesToCapturePerPacket { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("captureStartTime")]
    public DateTime? CaptureStartTime { get; set; }

    [MinItems(1)]
    [JsonPropertyName("networkInterfaces")]
    public List<string>? NetworkInterfaces { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("status")]
    public PacketCaptureStatusConstant? Status { get; set; }

    [JsonPropertyName("timeLimitInSeconds")]
    public int? TimeLimitInSeconds { get; set; }

    [JsonPropertyName("totalBytesPerSession")]
    public int? TotalBytesPerSession { get; set; }
}
