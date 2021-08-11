using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
{

    internal class SubnetModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
