using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{

    internal class Identity
    {
        [JsonPropertyName("principalId")]
        public string? PrincipalId { get; set; }

        [JsonPropertyName("tenantId")]
        public string? TenantId { get; set; }

        [JsonPropertyName("type")]
        public IdentityType Type { get; set; }
    }
}
