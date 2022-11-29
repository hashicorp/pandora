using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OperationalizationClusters;


internal class AKSSchemaPropertiesModel
{
    [JsonPropertyName("agentCount")]
    public int? AgentCount { get; set; }

    [JsonPropertyName("agentVmSize")]
    public string? AgentVMSize { get; set; }

    [JsonPropertyName("aksNetworkingConfiguration")]
    public AksNetworkingConfigurationModel? AksNetworkingConfiguration { get; set; }

    [JsonPropertyName("clusterFqdn")]
    public string? ClusterFqdn { get; set; }

    [JsonPropertyName("clusterPurpose")]
    public ClusterPurposeConstant? ClusterPurpose { get; set; }

    [JsonPropertyName("loadBalancerSubnet")]
    public string? LoadBalancerSubnet { get; set; }

    [JsonPropertyName("loadBalancerType")]
    public LoadBalancerTypeConstant? LoadBalancerType { get; set; }

    [JsonPropertyName("sslConfiguration")]
    public SslConfigurationModel? SslConfiguration { get; set; }

    [JsonPropertyName("systemServices")]
    public List<SystemServiceModel>? SystemServices { get; set; }
}
