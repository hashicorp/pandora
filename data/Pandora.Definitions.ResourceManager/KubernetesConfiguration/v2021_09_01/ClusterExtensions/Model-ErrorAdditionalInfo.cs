using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.ClusterExtensions;


internal class ErrorAdditionalInfoModel
{
    [JsonPropertyName("info")]
    public object? Info { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
