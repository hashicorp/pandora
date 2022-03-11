using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;


internal class WsdlServiceModel
{
    [JsonPropertyName("endpointQualifiedNames")]
    public List<string>? EndpointQualifiedNames { get; set; }

    [JsonPropertyName("qualifiedName")]
    [Required]
    public string QualifiedName { get; set; }
}
