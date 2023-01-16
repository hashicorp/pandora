using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;


internal class NetworkInterfacePropertiesModel
{
    [JsonPropertyName("dnsName")]
    public string? DnsName { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIPAddress { get; set; }

    [JsonPropertyName("publicIpAddressId")]
    public string? PublicIPAddressId { get; set; }

    [JsonPropertyName("rdpAuthority")]
    public string? RdpAuthority { get; set; }

    [JsonPropertyName("sharedPublicIpAddressConfiguration")]
    public SharedPublicIPAddressConfigurationModel? SharedPublicIPAddressConfiguration { get; set; }

    [JsonPropertyName("sshAuthority")]
    public string? SshAuthority { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("virtualNetworkId")]
    public string? VirtualNetworkId { get; set; }
}
