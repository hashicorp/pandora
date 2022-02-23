using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobInventoryPolicies;


internal class BlobInventoryPolicyRuleModel
{
    [JsonPropertyName("definition")]
    [Required]
    public BlobInventoryPolicyDefinitionModel Definition { get; set; }

    [JsonPropertyName("destination")]
    [Required]
    public string Destination { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
