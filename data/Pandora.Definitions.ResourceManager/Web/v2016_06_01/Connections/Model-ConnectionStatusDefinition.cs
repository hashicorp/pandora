using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;


internal class ConnectionStatusDefinitionModel
{
    [JsonPropertyName("error")]
    public ConnectionErrorModel? Error { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
