using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;


internal class CacheNetworkSettingsModel
{
    [JsonPropertyName("dnsSearchDomain")]
    public string? DnsSearchDomain { get; set; }

    [JsonPropertyName("dnsServers")]
    public List<string>? DnsServers { get; set; }

    [JsonPropertyName("mtu")]
    public int? Mtu { get; set; }

    [JsonPropertyName("ntpServer")]
    public string? NtpServer { get; set; }

    [JsonPropertyName("utilityAddresses")]
    public List<string>? UtilityAddresses { get; set; }
}
