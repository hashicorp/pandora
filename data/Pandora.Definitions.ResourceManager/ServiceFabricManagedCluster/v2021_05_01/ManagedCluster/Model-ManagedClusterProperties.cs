using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster;


internal class ManagedClusterPropertiesModel
{
    [JsonPropertyName("addonFeatures")]
    public List<AddonFeaturesConstant>? AddonFeatures { get; set; }

    [JsonPropertyName("adminPassword")]
    public string? AdminPassword { get; set; }

    [JsonPropertyName("adminUserName")]
    [Required]
    public string AdminUserName { get; set; }

    [JsonPropertyName("allowRdpAccess")]
    public bool? AllowRdpAccess { get; set; }

    [JsonPropertyName("applicationTypeVersionsCleanupPolicy")]
    public ApplicationTypeVersionsCleanupPolicyModel? ApplicationTypeVersionsCleanupPolicy { get; set; }

    [JsonPropertyName("azureActiveDirectory")]
    public AzureActiveDirectoryModel? AzureActiveDirectory { get; set; }

    [JsonPropertyName("clientConnectionPort")]
    public int? ClientConnectionPort { get; set; }

    [JsonPropertyName("clients")]
    public List<ClientCertificateModel>? Clients { get; set; }

    [JsonPropertyName("clusterCertificateThumbprints")]
    public List<string>? ClusterCertificateThumbprints { get; set; }

    [JsonPropertyName("clusterCodeVersion")]
    public string? ClusterCodeVersion { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("clusterState")]
    public ClusterStateConstant? ClusterState { get; set; }

    [JsonPropertyName("clusterUpgradeCadence")]
    public ClusterUpgradeCadenceConstant? ClusterUpgradeCadence { get; set; }

    [JsonPropertyName("clusterUpgradeMode")]
    public ClusterUpgradeModeConstant? ClusterUpgradeMode { get; set; }

    [JsonPropertyName("dnsName")]
    [Required]
    public string DnsName { get; set; }

    [JsonPropertyName("enableAutoOSUpgrade")]
    public bool? EnableAutoOSUpgrade { get; set; }

    [JsonPropertyName("fabricSettings")]
    public List<SettingsSectionDescriptionModel>? FabricSettings { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("httpGatewayConnectionPort")]
    public int? HTTPGatewayConnectionPort { get; set; }

    [JsonPropertyName("ipv4Address")]
    public string? IPv4Address { get; set; }

    [JsonPropertyName("loadBalancingRules")]
    public List<LoadBalancingRuleModel>? LoadBalancingRules { get; set; }

    [JsonPropertyName("networkSecurityRules")]
    public List<NetworkSecurityRuleModel>? NetworkSecurityRules { get; set; }

    [JsonPropertyName("provisioningState")]
    public ManagedResourceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("zonalResiliency")]
    public bool? ZonalResiliency { get; set; }
}
