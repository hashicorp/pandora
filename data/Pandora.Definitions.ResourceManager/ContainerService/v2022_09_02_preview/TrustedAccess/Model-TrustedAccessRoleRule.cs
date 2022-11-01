using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.TrustedAccess;


internal class TrustedAccessRoleRuleModel
{
    [JsonPropertyName("apiGroups")]
    public List<string>? ApiGroups { get; set; }

    [JsonPropertyName("nonResourceURLs")]
    public List<string>? NonResourceURLs { get; set; }

    [JsonPropertyName("resourceNames")]
    public List<string>? ResourceNames { get; set; }

    [JsonPropertyName("resources")]
    public List<string>? Resources { get; set; }

    [JsonPropertyName("verbs")]
    public List<string>? Verbs { get; set; }
}
