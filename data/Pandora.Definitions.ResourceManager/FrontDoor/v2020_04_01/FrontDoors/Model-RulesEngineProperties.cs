using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class RulesEnginePropertiesModel
{
    [JsonPropertyName("resourceState")]
    public FrontDoorResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("rules")]
    public List<RulesEngineRuleModel>? Rules { get; set; }
}
