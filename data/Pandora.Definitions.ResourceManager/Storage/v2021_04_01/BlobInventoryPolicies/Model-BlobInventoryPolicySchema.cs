using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobInventoryPolicies;


internal class BlobInventoryPolicySchemaModel
{
    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("rules")]
    [Required]
    public List<BlobInventoryPolicyRuleModel> Rules { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public InventoryRuleTypeConstant Type { get; set; }
}
