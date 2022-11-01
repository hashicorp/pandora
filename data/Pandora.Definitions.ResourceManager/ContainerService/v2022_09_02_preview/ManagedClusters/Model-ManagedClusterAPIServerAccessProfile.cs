using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusters;


internal class ManagedClusterAPIServerAccessProfileModel
{
    [JsonPropertyName("authorizedIPRanges")]
    public List<string>? AuthorizedIPRanges { get; set; }

    [JsonPropertyName("disableRunCommand")]
    public bool? DisableRunCommand { get; set; }

    [JsonPropertyName("enablePrivateCluster")]
    public bool? EnablePrivateCluster { get; set; }

    [JsonPropertyName("enablePrivateClusterPublicFQDN")]
    public bool? EnablePrivateClusterPublicFQDN { get; set; }

    [JsonPropertyName("enableVnetIntegration")]
    public bool? EnableVnetIntegration { get; set; }

    [JsonPropertyName("privateDNSZone")]
    public string? PrivateDNSZone { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }
}
