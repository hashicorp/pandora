using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class VirtualNetworkRuleModel
{
    [JsonPropertyName("action")]
    public ActionConstant? Action { get; set; }

    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }
}
