using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.ManagedClusters;


internal class ManagedClusterPropertiesModel
{
    [JsonPropertyName("aadProfile")]
    public ManagedClusterAADProfileModel? AadProfile { get; set; }

    [JsonPropertyName("addonProfiles")]
    public Dictionary<string, ManagedClusterAddonProfileModel>? AddonProfiles { get; set; }

    [JsonPropertyName("agentPoolProfiles")]
    public List<ManagedClusterAgentPoolProfileModel>? AgentPoolProfiles { get; set; }

    [JsonPropertyName("apiServerAccessProfile")]
    public ManagedClusterAPIServerAccessProfileModel? ApiServerAccessProfile { get; set; }

    [JsonPropertyName("autoScalerProfile")]
    public ManagedClusterPropertiesAutoScalerProfileModel? AutoScalerProfile { get; set; }

    [JsonPropertyName("autoUpgradeProfile")]
    public ManagedClusterAutoUpgradeProfileModel? AutoUpgradeProfile { get; set; }

    [JsonPropertyName("azureMonitorProfile")]
    public ManagedClusterAzureMonitorProfileModel? AzureMonitorProfile { get; set; }

    [JsonPropertyName("azurePortalFQDN")]
    public string? AzurePortalFQDN { get; set; }

    [JsonPropertyName("currentKubernetesVersion")]
    public string? CurrentKubernetesVersion { get; set; }

    [JsonPropertyName("disableLocalAccounts")]
    public bool? DisableLocalAccounts { get; set; }

    [JsonPropertyName("diskEncryptionSetID")]
    public string? DiskEncryptionSetID { get; set; }

    [JsonPropertyName("dnsPrefix")]
    public string? DnsPrefix { get; set; }

    [JsonPropertyName("enablePodSecurityPolicy")]
    public bool? EnablePodSecurityPolicy { get; set; }

    [JsonPropertyName("enableRBAC")]
    public bool? EnableRBAC { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("fqdnSubdomain")]
    public string? FqdnSubdomain { get; set; }

    [JsonPropertyName("httpProxyConfig")]
    public ManagedClusterHTTPProxyConfigModel? HTTPProxyConfig { get; set; }

    [JsonPropertyName("identityProfile")]
    public Dictionary<string, UserAssignedIdentityModel>? IdentityProfile { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [JsonPropertyName("linuxProfile")]
    public ContainerServiceLinuxProfileModel? LinuxProfile { get; set; }

    [JsonPropertyName("maxAgentPools")]
    public int? MaxAgentPools { get; set; }

    [JsonPropertyName("networkProfile")]
    public ContainerServiceNetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("nodeResourceGroup")]
    public string? NodeResourceGroup { get; set; }

    [JsonPropertyName("oidcIssuerProfile")]
    public ManagedClusterOIDCIssuerProfileModel? OidcIssuerProfile { get; set; }

    [JsonPropertyName("podIdentityProfile")]
    public ManagedClusterPodIdentityProfileModel? PodIdentityProfile { get; set; }

    [JsonPropertyName("powerState")]
    public PowerStateModel? PowerState { get; set; }

    [JsonPropertyName("privateFQDN")]
    public string? PrivateFQDN { get; set; }

    [JsonPropertyName("privateLinkResources")]
    public List<PrivateLinkResourceModel>? PrivateLinkResources { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("securityProfile")]
    public ManagedClusterSecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("servicePrincipalProfile")]
    public ManagedClusterServicePrincipalProfileModel? ServicePrincipalProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public ManagedClusterStorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("windowsProfile")]
    public ManagedClusterWindowsProfileModel? WindowsProfile { get; set; }

    [JsonPropertyName("workloadAutoScalerProfile")]
    public ManagedClusterWorkloadAutoScalerProfileModel? WorkloadAutoScalerProfile { get; set; }
}
