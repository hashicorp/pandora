using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{

    internal class AutoScaleVCoreProperties
    {
        [JsonPropertyName("capacityLimit")]
        public int? CapacityLimit { get; set; }

        [JsonPropertyName("capacityObjectId")]
        public string? CapacityObjectId { get; set; }

        [JsonPropertyName("provisioningState")]
        public VCoreProvisioningState? ProvisioningState { get; set; }
    }
}
