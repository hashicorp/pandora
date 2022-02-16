using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;


internal class ListClusterUserCredentialPropertiesModel
{
    [JsonPropertyName("authenticationMethod")]
    [Required]
    public AuthenticationMethodConstant AuthenticationMethod { get; set; }

    [JsonPropertyName("clientProxy")]
    [Required]
    public bool ClientProxy { get; set; }
}
