using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;


internal class ApiOAuthSettingsParameterModel
{
    [JsonPropertyName("options")]
    public object? Options { get; set; }

    [JsonPropertyName("uiDefinition")]
    public object? UiDefinition { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
