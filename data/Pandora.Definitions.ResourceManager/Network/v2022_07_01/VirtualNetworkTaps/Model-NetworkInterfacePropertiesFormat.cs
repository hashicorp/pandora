using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkTaps;


internal class NetworkInterfacePropertiesFormatModel
{
    [JsonPropertyName("auxiliaryMode")]
    public NetworkInterfaceAuxiliaryModeConstant? AuxiliaryMode { get; set; }

    [JsonPropertyName("disableTcpStateTracking")]
    public bool? DisableTcpStateTracking { get; set; }

    [JsonPropertyName("dnsSettings")]
    public NetworkInterfaceDnsSettingsModel? DnsSettings { get; set; }

    [JsonPropertyName("dscpConfiguration")]
    public SubResourceModel? DscpConfiguration { get; set; }

    [JsonPropertyName("enableAcceleratedNetworking")]
    public bool? EnableAcceleratedNetworking { get; set; }

    [JsonPropertyName("enableIPForwarding")]
    public bool? EnableIPForwarding { get; set; }

    [JsonPropertyName("hostedWorkloads")]
    public List<string>? HostedWorkloads { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<NetworkInterfaceIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("migrationPhase")]
    public NetworkInterfaceMigrationPhaseConstant? MigrationPhase { get; set; }

    [JsonPropertyName("networkSecurityGroup")]
    public NetworkSecurityGroupModel? NetworkSecurityGroup { get; set; }

    [JsonPropertyName("nicType")]
    public NetworkInterfaceNicTypeConstant? NicType { get; set; }

    [JsonPropertyName("primary")]
    public bool? Primary { get; set; }

    [JsonPropertyName("privateEndpoint")]
    public PrivateEndpointModel? PrivateEndpoint { get; set; }

    [JsonPropertyName("privateLinkService")]
    public PrivateLinkServiceModel? PrivateLinkService { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("tapConfigurations")]
    public List<NetworkInterfaceTapConfigurationModel>? TapConfigurations { get; set; }

    [JsonPropertyName("virtualMachine")]
    public SubResourceModel? VirtualMachine { get; set; }

    [JsonPropertyName("vnetEncryptionSupported")]
    public bool? VnetEncryptionSupported { get; set; }

    [JsonPropertyName("workloadType")]
    public string? WorkloadType { get; set; }
}
