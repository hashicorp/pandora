using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{

    internal class CircuitModel
    {
        [JsonPropertyName("expressRouteID")]
        public string? ExpressRouteID { get; set; }

        [JsonPropertyName("expressRoutePrivatePeeringID")]
        public string? ExpressRoutePrivatePeeringID { get; set; }

        [JsonPropertyName("primarySubnet")]
        public string? PrimarySubnet { get; set; }

        [JsonPropertyName("secondarySubnet")]
        public string? SecondarySubnet { get; set; }
    }
}
