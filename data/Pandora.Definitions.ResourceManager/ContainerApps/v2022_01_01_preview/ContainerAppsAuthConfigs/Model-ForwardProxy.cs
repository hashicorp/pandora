using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class ForwardProxyModel
{
    [JsonPropertyName("convention")]
    public ForwardProxyConventionConstant? Convention { get; set; }

    [JsonPropertyName("customHostHeaderName")]
    public string? CustomHostHeaderName { get; set; }

    [JsonPropertyName("customProtoHeaderName")]
    public string? CustomProtoHeaderName { get; set; }
}
