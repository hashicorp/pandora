using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.LoadBalancers;


internal class PublicIPAddressPropertiesFormatModel
{
    [JsonPropertyName("ddosSettings")]
    public DdosSettingsModel? DdosSettings { get; set; }

    [JsonPropertyName("deleteOption")]
    public DeleteOptionsConstant? DeleteOption { get; set; }

    [JsonPropertyName("dnsSettings")]
    public PublicIPAddressDnsSettingsModel? DnsSettings { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("ipConfiguration")]
    public IPConfigurationModel? IPConfiguration { get; set; }

    [JsonPropertyName("ipTags")]
    public List<IPTagModel>? IPTags { get; set; }

    [JsonPropertyName("idleTimeoutInMinutes")]
    public int? IdleTimeoutInMinutes { get; set; }

    [JsonPropertyName("linkedPublicIPAddress")]
    public PublicIPAddressModel? LinkedPublicIPAddress { get; set; }

    [JsonPropertyName("migrationPhase")]
    public PublicIPAddressMigrationPhaseConstant? MigrationPhase { get; set; }

    [JsonPropertyName("natGateway")]
    public NatGatewayModel? NatGateway { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPAddressVersion")]
    public IPVersionConstant? PublicIPAddressVersion { get; set; }

    [JsonPropertyName("publicIPAllocationMethod")]
    public IPAllocationMethodConstant? PublicIPAllocationMethod { get; set; }

    [JsonPropertyName("publicIPPrefix")]
    public SubResourceModel? PublicIPPrefix { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("servicePublicIPAddress")]
    public PublicIPAddressModel? ServicePublicIPAddress { get; set; }
}
