using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{

    internal class ExpressRouteAuthorizationPropertiesModel
    {
        [JsonPropertyName("expressRouteAuthorizationId")]
        public string? ExpressRouteAuthorizationId { get; set; }

        [JsonPropertyName("expressRouteAuthorizationKey")]
        public string? ExpressRouteAuthorizationKey { get; set; }

        [JsonPropertyName("provisioningState")]
        public ExpressRouteAuthorizationProvisioningStateConstant? ProvisioningState { get; set; }
    }
}
