using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;


internal abstract class RouteConfigurationModel
{
    [JsonPropertyName("@odata.type")]
    [ProvidesTypeHint]
    [Required]
    public string OdataType { get; set; }
}
