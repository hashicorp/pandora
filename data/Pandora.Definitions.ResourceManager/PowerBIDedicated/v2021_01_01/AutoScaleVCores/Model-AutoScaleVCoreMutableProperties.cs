using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{

    internal class AutoScaleVCoreMutableProperties
    {
        [JsonPropertyName("capacityLimit")]
        public int? CapacityLimit { get; set; }
    }
}
