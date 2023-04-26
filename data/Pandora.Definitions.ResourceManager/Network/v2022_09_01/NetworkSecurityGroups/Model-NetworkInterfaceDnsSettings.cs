using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.NetworkSecurityGroups;


internal class NetworkInterfaceDnsSettingsModel
{
    [JsonPropertyName("appliedDnsServers")]
    public List<string>? AppliedDnsServers { get; set; }

    [JsonPropertyName("dnsServers")]
    public List<string>? DnsServers { get; set; }

    [JsonPropertyName("internalDnsNameLabel")]
    public string? InternalDnsNameLabel { get; set; }

    [JsonPropertyName("internalDomainNameSuffix")]
    public string? InternalDomainNameSuffix { get; set; }

    [JsonPropertyName("internalFqdn")]
    public string? InternalFqdn { get; set; }
}
