using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ValueForType("#Microsoft.Media.H265Video")]
internal class H265VideoModel : CodecModel
{
    [JsonPropertyName("complexity")]
    public H265ComplexityConstant? Complexity { get; set; }

    [JsonPropertyName("keyFrameInterval")]
    public string? KeyFrameInterval { get; set; }

    [JsonPropertyName("layers")]
    public List<H265LayerModel>? Layers { get; set; }

    [JsonPropertyName("sceneChangeDetection")]
    public bool? SceneChangeDetection { get; set; }

    [JsonPropertyName("stretchMode")]
    public StretchModeConstant? StretchMode { get; set; }

    [JsonPropertyName("syncMode")]
    public VideoSyncModeConstant? SyncMode { get; set; }
}
