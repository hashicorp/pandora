using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachineTemplates;


internal class NicIPSettingsModel
{
    [JsonPropertyName("allocationMethod")]
    public IPAddressAllocationMethodConstant? AllocationMethod { get; set; }

    [JsonPropertyName("dnsServers")]
    public List<string>? DnsServers { get; set; }

    [JsonPropertyName("gateway")]
    public List<string>? Gateway { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("ipAddressInfo")]
    public List<NicIPAddressSettingsModel>? IPAddressInfo { get; set; }

    [JsonPropertyName("primaryWinsServer")]
    public string? PrimaryWinsServer { get; set; }

    [JsonPropertyName("secondaryWinsServer")]
    public string? SecondaryWinsServer { get; set; }

    [JsonPropertyName("subnetMask")]
    public string? SubnetMask { get; set; }
}
