using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.Workspaces
{

    internal class WorkspaceProviderAuthorizationModel
    {
        [JsonPropertyName("principalId")]
        [Required]
        public string PrincipalId { get; set; }

        [JsonPropertyName("roleDefinitionId")]
        [Required]
        public string RoleDefinitionId { get; set; }
    }
}
