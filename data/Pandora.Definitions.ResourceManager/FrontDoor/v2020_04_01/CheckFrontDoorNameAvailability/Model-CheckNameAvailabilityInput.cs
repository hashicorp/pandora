using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.CheckFrontDoorNameAvailability;


internal class CheckNameAvailabilityInputModel
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ResourceTypeConstant Type { get; set; }
}
