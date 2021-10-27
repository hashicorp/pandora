using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies
{

    internal class PolicySettingsModel
    {
        [JsonPropertyName("customBlockResponseBody")]
        public string? CustomBlockResponseBody { get; set; }

        [JsonPropertyName("customBlockResponseStatusCode")]
        public int? CustomBlockResponseStatusCode { get; set; }

        [JsonPropertyName("enabledState")]
        public PolicyEnabledStateConstant? EnabledState { get; set; }

        [JsonPropertyName("mode")]
        public PolicyModeConstant? Mode { get; set; }

        [JsonPropertyName("redirectUrl")]
        public string? RedirectUrl { get; set; }
    }
}
