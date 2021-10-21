using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{

    internal class VideoAnalyzerUpdateModel
    {
        [JsonPropertyName("identity")]
        public VideoAnalyzerIdentityModel? Identity { get; set; }

        [JsonPropertyName("properties")]
        public VideoAnalyzerPropertiesUpdateModel? Properties { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
