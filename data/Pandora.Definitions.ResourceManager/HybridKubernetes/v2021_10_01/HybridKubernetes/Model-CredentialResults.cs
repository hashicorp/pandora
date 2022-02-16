using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;


internal class CredentialResultsModel
{
    [JsonPropertyName("hybridConnectionConfig")]
    public HybridConnectionConfigModel? HybridConnectionConfig { get; set; }

    [JsonPropertyName("kubeconfigs")]
    public List<CredentialResultModel>? Kubeconfigs { get; set; }
}
