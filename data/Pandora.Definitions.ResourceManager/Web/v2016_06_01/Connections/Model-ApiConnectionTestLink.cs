using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;


internal class ApiConnectionTestLinkModel
{
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("requestUri")]
    public string? RequestUri { get; set; }
}
