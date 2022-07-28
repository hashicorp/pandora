using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.PacketCaptures;


internal class PacketCaptureParametersModel
{
    [JsonPropertyName("bytesToCapturePerPacket")]
    public int? BytesToCapturePerPacket { get; set; }

    [JsonPropertyName("filters")]
    public List<PacketCaptureFilterModel>? Filters { get; set; }

    [JsonPropertyName("storageLocation")]
    [Required]
    public PacketCaptureStorageLocationModel StorageLocation { get; set; }

    [JsonPropertyName("target")]
    [Required]
    public string Target { get; set; }

    [JsonPropertyName("timeLimitInSeconds")]
    public int? TimeLimitInSeconds { get; set; }

    [JsonPropertyName("totalBytesPerSession")]
    public int? TotalBytesPerSession { get; set; }
}
