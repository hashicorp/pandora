using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.ManagedClusterSnapshots;


internal class NetworkProfileForSnapshotModel
{
    [JsonPropertyName("loadBalancerSku")]
    public LoadBalancerSkuConstant? LoadBalancerSku { get; set; }

    [JsonPropertyName("networkMode")]
    public NetworkModeConstant? NetworkMode { get; set; }

    [JsonPropertyName("networkPlugin")]
    public NetworkPluginConstant? NetworkPlugin { get; set; }

    [JsonPropertyName("networkPluginMode")]
    public NetworkPluginModeConstant? NetworkPluginMode { get; set; }

    [JsonPropertyName("networkPolicy")]
    public NetworkPolicyConstant? NetworkPolicy { get; set; }
}
