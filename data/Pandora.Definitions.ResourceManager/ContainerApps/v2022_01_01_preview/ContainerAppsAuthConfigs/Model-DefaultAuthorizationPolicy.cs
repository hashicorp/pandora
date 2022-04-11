using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class DefaultAuthorizationPolicyModel
{
    [JsonPropertyName("allowedApplications")]
    public List<string>? AllowedApplications { get; set; }

    [JsonPropertyName("allowedPrincipals")]
    public AllowedPrincipalsModel? AllowedPrincipals { get; set; }
}
