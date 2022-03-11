using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;


internal class WsdlDefinitionModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("importMethod")]
    public WsdlImportMethodConstant? ImportMethod { get; set; }

    [JsonPropertyName("service")]
    public WsdlServiceModel? Service { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
