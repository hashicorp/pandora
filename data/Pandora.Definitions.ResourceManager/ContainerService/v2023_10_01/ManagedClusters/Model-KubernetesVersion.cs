using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.ManagedClusters;


internal class KubernetesVersionModel
{
    [JsonPropertyName("capabilities")]
    public KubernetesVersionCapabilitiesModel? Capabilities { get; set; }

    [JsonPropertyName("isPreview")]
    public bool? IsPreview { get; set; }

    [JsonPropertyName("patchVersions")]
    public Dictionary<string, KubernetesPatchVersionModel>? PatchVersions { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
