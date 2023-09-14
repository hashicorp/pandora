using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MachinesController;


internal class VMwareNetworkAdapterModel
{
    [JsonPropertyName("adapterType")]
    public string? AdapterType { get; set; }

    [JsonPropertyName("ipAddressList")]
    public List<string>? IPAddressList { get; set; }

    [JsonPropertyName("ipAddressType")]
    public string? IPAddressType { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("networkName")]
    public string? NetworkName { get; set; }

    [JsonPropertyName("nicId")]
    public string? NicId { get; set; }
}
