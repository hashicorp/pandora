using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusterSnapshots;


internal class ManagedClusterPropertiesForSnapshotModel
{
    [JsonPropertyName("enableRbac")]
    public bool? EnableRbac { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileForSnapshotModel? NetworkProfile { get; set; }

    [JsonPropertyName("sku")]
    public ManagedClusterSKUModel? Sku { get; set; }
}
