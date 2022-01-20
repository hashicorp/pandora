using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;


internal class SkuChangeInfoModel
{
    [JsonPropertyName("countOfDowngrades")]
    public float? CountOfDowngrades { get; set; }

    [JsonPropertyName("countOfUpgradesAfterDowngrades")]
    public float? CountOfUpgradesAfterDowngrades { get; set; }

    [JsonPropertyName("lastChangeDate")]
    public string? LastChangeDate { get; set; }
}
