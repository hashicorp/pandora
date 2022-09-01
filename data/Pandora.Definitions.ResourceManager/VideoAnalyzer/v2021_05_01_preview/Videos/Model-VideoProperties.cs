using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.Videos;


internal class VideoPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("flags")]
    public VideoFlagsModel? Flags { get; set; }

    [JsonPropertyName("mediaInfo")]
    public VideoMediaInfoModel? MediaInfo { get; set; }

    [JsonPropertyName("streaming")]
    public VideoStreamingModel? Streaming { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public VideoTypeConstant? Type { get; set; }
}
