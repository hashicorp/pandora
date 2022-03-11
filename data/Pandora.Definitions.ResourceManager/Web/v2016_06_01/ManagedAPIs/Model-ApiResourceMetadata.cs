using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;


internal class ApiResourceMetadataModel
{
    [JsonPropertyName("apiType")]
    public ApiTypeConstant? ApiType { get; set; }

    [JsonPropertyName("brandColor")]
    public string? BrandColor { get; set; }

    [JsonPropertyName("connectionType")]
    public string? ConnectionType { get; set; }

    [JsonPropertyName("hideKey")]
    public string? HideKey { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("wsdlImportMethod")]
    public WsdlImportMethodConstant? WsdlImportMethod { get; set; }

    [JsonPropertyName("wsdlService")]
    public WsdlServiceModel? WsdlService { get; set; }
}
