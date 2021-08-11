using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.EventHubs
{

    internal class CaptureDescriptionModel
    {
        [JsonPropertyName("destination")]
        public DestinationModel? Destination { get; set; }

        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }

        [JsonPropertyName("encoding")]
        public EncodingCaptureDescriptionConstant? Encoding { get; set; }

        [JsonPropertyName("intervalInSeconds")]
        public int? IntervalInSeconds { get; set; }

        [JsonPropertyName("sizeLimitInBytes")]
        public int? SizeLimitInBytes { get; set; }

        [JsonPropertyName("skipEmptyArchives")]
        public bool? SkipEmptyArchives { get; set; }
    }
}
