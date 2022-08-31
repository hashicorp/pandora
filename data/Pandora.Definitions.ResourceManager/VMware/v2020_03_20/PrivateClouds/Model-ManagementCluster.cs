using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds;


internal class ManagementClusterModel
{
    [JsonPropertyName("clusterId")]
    public int? ClusterId { get; set; }

    [JsonPropertyName("clusterSize")]
    [Required]
    public int ClusterSize { get; set; }

    [JsonPropertyName("hosts")]
    public List<string>? Hosts { get; set; }

    [JsonPropertyName("provisioningState")]
    public ClusterProvisioningStateConstant? ProvisioningState { get; set; }
}
