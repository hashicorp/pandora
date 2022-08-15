using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ValueForType("#Microsoft.Media.VideoOverlay")]
internal class VideoOverlayModel : OverlayModel
{
    [JsonPropertyName("cropRectangle")]
    public RectangleModel? CropRectangle { get; set; }

    [JsonPropertyName("opacity")]
    public float? Opacity { get; set; }

    [JsonPropertyName("position")]
    public RectangleModel? Position { get; set; }
}
