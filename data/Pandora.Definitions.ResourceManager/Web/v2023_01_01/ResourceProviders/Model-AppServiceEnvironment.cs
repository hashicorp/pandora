using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;


internal class AppServiceEnvironmentModel
{
    [JsonPropertyName("clusterSettings")]
    public List<NameValuePairModel>? ClusterSettings { get; set; }

    [JsonPropertyName("customDnsSuffixConfiguration")]
    public CustomDnsSuffixConfigurationModel? CustomDnsSuffixConfiguration { get; set; }

    [JsonPropertyName("dedicatedHostCount")]
    public int? DedicatedHostCount { get; set; }

    [JsonPropertyName("dnsSuffix")]
    public string? DnsSuffix { get; set; }

    [JsonPropertyName("frontEndScaleFactor")]
    public int? FrontEndScaleFactor { get; set; }

    [JsonPropertyName("hasLinuxWorkers")]
    public bool? HasLinuxWorkers { get; set; }

    [JsonPropertyName("ipsslAddressCount")]
    public int? IPsslAddressCount { get; set; }

    [JsonPropertyName("internalLoadBalancingMode")]
    public LoadBalancingModeConstant? InternalLoadBalancingMode { get; set; }

    [JsonPropertyName("maximumNumberOfMachines")]
    public int? MaximumNumberOfMachines { get; set; }

    [JsonPropertyName("multiRoleCount")]
    public int? MultiRoleCount { get; set; }

    [JsonPropertyName("multiSize")]
    public string? MultiSize { get; set; }

    [JsonPropertyName("networkingConfiguration")]
    public AseV3NetworkingConfigurationModel? NetworkingConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public HostingEnvironmentStatusConstant? Status { get; set; }

    [JsonPropertyName("suspended")]
    public bool? Suspended { get; set; }

    [JsonPropertyName("upgradeAvailability")]
    public UpgradeAvailabilityConstant? UpgradeAvailability { get; set; }

    [JsonPropertyName("upgradePreference")]
    public UpgradePreferenceConstant? UpgradePreference { get; set; }

    [JsonPropertyName("userWhitelistedIpRanges")]
    public List<string>? UserWhitelistedIPRanges { get; set; }

    [JsonPropertyName("virtualNetwork")]
    [Required]
    public VirtualNetworkProfileModel VirtualNetwork { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
