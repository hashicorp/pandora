using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{
    [ValueForType("#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration")]
    internal class ForwardingConfigurationModel : RouteConfigurationModel
    {
        [JsonPropertyName("backendPool")]
        public SubResourceModel? BackendPool { get; set; }

        [JsonPropertyName("cacheConfiguration")]
        public CacheConfigurationModel? CacheConfiguration { get; set; }

        [JsonPropertyName("customForwardingPath")]
        public string? CustomForwardingPath { get; set; }

        [JsonPropertyName("forwardingProtocol")]
        public FrontDoorForwardingProtocolConstant? ForwardingProtocol { get; set; }
    }
}
