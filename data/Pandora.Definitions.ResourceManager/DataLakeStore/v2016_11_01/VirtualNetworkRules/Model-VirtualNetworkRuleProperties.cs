using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.VirtualNetworkRules
{

    internal class VirtualNetworkRulePropertiesModel
    {
        [JsonPropertyName("subnetId")]
        public string? SubnetId { get; set; }
    }
}
