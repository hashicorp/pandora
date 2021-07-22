using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.DisasterRecoveryConfigs
{

    internal class ArmDisasterRecoveryListResult
    {
        [JsonPropertyName("nextLink")]
        public string? NextLink { get; set; }

        [JsonPropertyName("value")]
        public List<ArmDisasterRecovery>? Value { get; set; }
    }
}
