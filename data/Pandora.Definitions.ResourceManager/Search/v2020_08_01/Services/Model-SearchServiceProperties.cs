using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;


internal class SearchServicePropertiesModel
{
    [JsonPropertyName("hostingMode")]
    public HostingModeConstant? HostingMode { get; set; }

    [JsonPropertyName("networkRuleSet")]
    public NetworkRuleSetModel? NetworkRuleSet { get; set; }

    [JsonPropertyName("partitionCount")]
    public int? PartitionCount { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("replicaCount")]
    public int? ReplicaCount { get; set; }

    [JsonPropertyName("sharedPrivateLinkResources")]
    public List<SharedPrivateLinkResourceModel>? SharedPrivateLinkResources { get; set; }

    [JsonPropertyName("status")]
    public SearchServiceStatusConstant? Status { get; set; }

    [JsonPropertyName("statusDetails")]
    public string? StatusDetails { get; set; }
}
