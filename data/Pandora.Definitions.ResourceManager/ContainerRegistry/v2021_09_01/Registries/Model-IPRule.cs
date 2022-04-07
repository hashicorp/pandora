using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class IPRuleModel
{
    [JsonPropertyName("action")]
    public ActionConstant? Action { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
