using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusters;


internal class ManagedClusterLoadBalancerProfileModel
{
    [JsonPropertyName("allocatedOutboundPorts")]
    public int? AllocatedOutboundPorts { get; set; }

    [JsonPropertyName("backendPoolType")]
    public BackendPoolTypeConstant? BackendPoolType { get; set; }

    [JsonPropertyName("effectiveOutboundIPs")]
    public List<ResourceReferenceModel>? EffectiveOutboundIPs { get; set; }

    [JsonPropertyName("enableMultipleStandardLoadBalancers")]
    public bool? EnableMultipleStandardLoadBalancers { get; set; }

    [JsonPropertyName("idleTimeoutInMinutes")]
    public int? IdleTimeoutInMinutes { get; set; }

    [JsonPropertyName("managedOutboundIPs")]
    public ManagedClusterLoadBalancerProfileManagedOutboundIPsModel? ManagedOutboundIPs { get; set; }

    [JsonPropertyName("outboundIPPrefixes")]
    public ManagedClusterLoadBalancerProfileOutboundIPPrefixesModel? OutboundIPPrefixes { get; set; }

    [JsonPropertyName("outboundIPs")]
    public ManagedClusterLoadBalancerProfileOutboundIPsModel? OutboundIPs { get; set; }
}
