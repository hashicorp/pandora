using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PublicIPPrefixes;


internal class PublicIPPrefixPropertiesFormatModel
{
    [JsonPropertyName("customIPPrefix")]
    public SubResourceModel? CustomIPPrefix { get; set; }

    [JsonPropertyName("ipPrefix")]
    public string? IPPrefix { get; set; }

    [JsonPropertyName("ipTags")]
    public List<IPTagModel>? IPTags { get; set; }

    [JsonPropertyName("loadBalancerFrontendIpConfiguration")]
    public SubResourceModel? LoadBalancerFrontendIPConfiguration { get; set; }

    [JsonPropertyName("natGateway")]
    public NatGatewayModel? NatGateway { get; set; }

    [JsonPropertyName("prefixLength")]
    public int? PrefixLength { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPAddressVersion")]
    public IPVersionConstant? PublicIPAddressVersion { get; set; }

    [JsonPropertyName("publicIPAddresses")]
    public List<ReferencedPublicIPAddressModel>? PublicIPAddresses { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }
}
