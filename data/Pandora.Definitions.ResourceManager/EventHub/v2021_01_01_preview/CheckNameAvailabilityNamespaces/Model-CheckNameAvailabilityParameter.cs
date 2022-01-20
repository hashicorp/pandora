using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.CheckNameAvailabilityNamespaces;


internal class CheckNameAvailabilityParameterModel
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
