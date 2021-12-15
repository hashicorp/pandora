using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{

    internal class IdentityModel
    {
        [JsonPropertyName("principalId")]
        public string? PrincipalId { get; set; }

        [JsonPropertyName("tenantId")]
        public string? TenantId { get; set; }

        [JsonPropertyName("type")]
        public TypeConstant? Type { get; set; }

        [JsonPropertyName("userAssignedIdentities")]
        public Dictionary<string, UserAssignedIdentityModel>? UserAssignedIdentities { get; set; }
    }
}
