using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVMachines;


internal class HyperVNetworkAdapterModel
{
    [JsonPropertyName("ipAddressList")]
    public List<string>? IPAddressList { get; set; }

    [JsonPropertyName("ipAddressType")]
    public string? IPAddressType { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("networkId")]
    public string? NetworkId { get; set; }

    [JsonPropertyName("networkName")]
    public string? NetworkName { get; set; }

    [JsonPropertyName("nicId")]
    public string? NicId { get; set; }

    [JsonPropertyName("nicType")]
    public string? NicType { get; set; }

    [JsonPropertyName("staticIpAddress")]
    public string? StaticIPAddress { get; set; }

    [JsonPropertyName("subnetName")]
    public string? SubnetName { get; set; }
}
