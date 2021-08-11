using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{

    internal class IdentityUserAssignedIdentitiesModel
    {
        [JsonPropertyName("clientId")]
        public string? ClientId { get; set; }

        [JsonPropertyName("principalId")]
        public string? PrincipalId { get; set; }
    }
}
