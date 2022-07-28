using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.PrivateDnsZoneGroups;


internal class RecordSetModel
{
    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("recordSetName")]
    public string? RecordSetName { get; set; }

    [JsonPropertyName("recordType")]
    public string? RecordType { get; set; }

    [JsonPropertyName("ttl")]
    public int? Ttl { get; set; }
}
