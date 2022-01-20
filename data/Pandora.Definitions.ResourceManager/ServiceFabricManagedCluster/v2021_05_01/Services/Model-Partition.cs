using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Services;


internal abstract class PartitionModel
{
    [JsonPropertyName("partitionScheme")]
    [ProvidesTypeHint]
    [Required]
    public PartitionSchemeConstant PartitionScheme { get; set; }
}
