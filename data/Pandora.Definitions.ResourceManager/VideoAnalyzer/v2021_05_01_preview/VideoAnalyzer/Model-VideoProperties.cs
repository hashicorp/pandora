using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


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
