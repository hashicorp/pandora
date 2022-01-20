using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class LoadBalancingSettingsPropertiesModel
{
    [JsonPropertyName("additionalLatencyMilliseconds")]
    public int? AdditionalLatencyMilliseconds { get; set; }

    [JsonPropertyName("resourceState")]
    public FrontDoorResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("sampleSize")]
    public int? SampleSize { get; set; }

    [JsonPropertyName("successfulSamplesRequired")]
    public int? SuccessfulSamplesRequired { get; set; }
}
