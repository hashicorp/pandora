// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PhotoModel
{
    [JsonPropertyName("cameraMake")]
    public string? CameraMake { get; set; }

    [JsonPropertyName("cameraModel")]
    public string? CameraModel { get; set; }

    [JsonPropertyName("iso")]
    public int? Iso { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orientation")]
    public short? Orientation { get; set; }

    [JsonPropertyName("takenDateTime")]
    public DateTime? TakenDateTime { get; set; }
}
