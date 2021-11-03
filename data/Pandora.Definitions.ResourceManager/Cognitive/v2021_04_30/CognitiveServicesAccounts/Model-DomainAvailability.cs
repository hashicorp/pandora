using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class DomainAvailabilityModel
    {
        [JsonPropertyName("isSubdomainAvailable")]
        public bool? IsSubdomainAvailable { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("subdomainName")]
        public string? SubdomainName { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
