using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{

    internal class DedicatedCapacityPropertiesModel
    {
        [JsonPropertyName("administration")]
        public DedicatedCapacityAdministratorsModel? Administration { get; set; }

        [JsonPropertyName("mode")]
        public ModeConstant? Mode { get; set; }

        [JsonPropertyName("provisioningState")]
        public CapacityProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("state")]
        public StateConstant? State { get; set; }
    }
}
