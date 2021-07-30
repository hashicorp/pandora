using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{

    internal class DedicatedCapacityProperties
    {
        [JsonPropertyName("administration")]
        public DedicatedCapacityAdministrators? Administration { get; set; }

        [JsonPropertyName("mode")]
        public Mode? Mode { get; set; }

        [JsonPropertyName("provisioningState")]
        public CapacityProvisioningState? ProvisioningState { get; set; }

        [JsonPropertyName("state")]
        public State? State { get; set; }
    }
}
