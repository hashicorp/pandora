using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools;


internal class EndpointDependencyModel
{
    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("endpointDetails")]
    public List<EndpointDetailModel>? EndpointDetails { get; set; }
}
