using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{

    internal class UserAssignedIdentityModel
    {
        [JsonPropertyName("clientId")]
        public string? ClientId { get; set; }

        [JsonPropertyName("principalId")]
        public string? PrincipalId { get; set; }
    }
}
