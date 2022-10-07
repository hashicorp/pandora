using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.AgentPools;


internal class AgentPoolUpgradeProfilePropertiesModel
{
    [JsonPropertyName("kubernetesVersion")]
    [Required]
    public string KubernetesVersion { get; set; }

    [JsonPropertyName("latestNodeImageVersion")]
    public string? LatestNodeImageVersion { get; set; }

    [JsonPropertyName("osType")]
    [Required]
    public OSTypeConstant OsType { get; set; }

    [JsonPropertyName("upgrades")]
    public List<AgentPoolUpgradeProfilePropertiesUpgradesInlinedModel>? Upgrades { get; set; }
}
