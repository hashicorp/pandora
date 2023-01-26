using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkInterfaces;


internal class SubnetPropertiesFormatModel
{
    [JsonPropertyName("addressPrefix")]
    public string? AddressPrefix { get; set; }

    [JsonPropertyName("addressPrefixes")]
    public List<string>? AddressPrefixes { get; set; }

    [JsonPropertyName("applicationGatewayIpConfigurations")]
    public List<ApplicationGatewayIPConfigurationModel>? ApplicationGatewayIPConfigurations { get; set; }

    [JsonPropertyName("delegations")]
    public List<DelegationModel>? Delegations { get; set; }

    [JsonPropertyName("ipAllocations")]
    public List<SubResourceModel>? IPAllocations { get; set; }

    [JsonPropertyName("ipConfigurationProfiles")]
    public List<IPConfigurationProfileModel>? IPConfigurationProfiles { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<IPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("natGateway")]
    public SubResourceModel? NatGateway { get; set; }

    [JsonPropertyName("networkSecurityGroup")]
    public NetworkSecurityGroupModel? NetworkSecurityGroup { get; set; }

    [JsonPropertyName("privateEndpointNetworkPolicies")]
    public VirtualNetworkPrivateEndpointNetworkPoliciesConstant? PrivateEndpointNetworkPolicies { get; set; }

    [JsonPropertyName("privateEndpoints")]
    public List<PrivateEndpointModel>? PrivateEndpoints { get; set; }

    [JsonPropertyName("privateLinkServiceNetworkPolicies")]
    public VirtualNetworkPrivateLinkServiceNetworkPoliciesConstant? PrivateLinkServiceNetworkPolicies { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("purpose")]
    public string? Purpose { get; set; }

    [JsonPropertyName("resourceNavigationLinks")]
    public List<ResourceNavigationLinkModel>? ResourceNavigationLinks { get; set; }

    [JsonPropertyName("routeTable")]
    public RouteTableModel? RouteTable { get; set; }

    [JsonPropertyName("serviceAssociationLinks")]
    public List<ServiceAssociationLinkModel>? ServiceAssociationLinks { get; set; }

    [JsonPropertyName("serviceEndpointPolicies")]
    public List<ServiceEndpointPolicyModel>? ServiceEndpointPolicies { get; set; }

    [JsonPropertyName("serviceEndpoints")]
    public List<ServiceEndpointPropertiesFormatModel>? ServiceEndpoints { get; set; }
}
