using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.Extensions;


internal class ScopeModel
{
    [JsonPropertyName("cluster")]
    public ScopeClusterModel? Cluster { get; set; }

    [JsonPropertyName("namespace")]
    public ScopeNamespaceModel? Namespace { get; set; }
}
