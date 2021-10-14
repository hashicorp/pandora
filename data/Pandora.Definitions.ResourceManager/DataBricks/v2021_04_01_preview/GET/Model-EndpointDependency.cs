using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.GET
{

    internal class EndpointDependencyModel
    {
        [JsonPropertyName("domainName")]
        public string? DomainName { get; set; }

        [JsonPropertyName("endpointDetails")]
        public List<EndpointDetailModel>? EndpointDetails { get; set; }
    }
}
