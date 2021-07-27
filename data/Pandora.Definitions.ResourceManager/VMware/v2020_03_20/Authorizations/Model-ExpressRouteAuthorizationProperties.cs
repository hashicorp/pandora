using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{

    internal class ExpressRouteAuthorizationProperties
    {
        [JsonPropertyName("expressRouteAuthorizationId")]
        public string? ExpressRouteAuthorizationId { get; set; }

        [JsonPropertyName("expressRouteAuthorizationKey")]
        public string? ExpressRouteAuthorizationKey { get; set; }

        [JsonPropertyName("provisioningState")]
        public ExpressRouteAuthorizationProvisioningState? ProvisioningState { get; set; }
    }
}
