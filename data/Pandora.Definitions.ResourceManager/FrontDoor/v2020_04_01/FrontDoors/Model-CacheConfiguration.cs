using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class CacheConfigurationModel
{
    [JsonPropertyName("cacheDuration")]
    public string? CacheDuration { get; set; }

    [JsonPropertyName("dynamicCompression")]
    public DynamicCompressionEnabledConstant? DynamicCompression { get; set; }

    [JsonPropertyName("queryParameterStripDirective")]
    public FrontDoorQueryConstant? QueryParameterStripDirective { get; set; }

    [JsonPropertyName("queryParameters")]
    public string? QueryParameters { get; set; }
}
