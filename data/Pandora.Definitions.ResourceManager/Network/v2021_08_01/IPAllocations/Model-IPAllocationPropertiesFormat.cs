using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.IPAllocations;


internal class IPAllocationPropertiesFormatModel
{
    [JsonPropertyName("allocationTags")]
    public Dictionary<string, string>? AllocationTags { get; set; }

    [JsonPropertyName("ipamAllocationId")]
    public string? IPamAllocationId { get; set; }

    [JsonPropertyName("prefix")]
    public string? Prefix { get; set; }

    [JsonPropertyName("prefixLength")]
    public int? PrefixLength { get; set; }

    [JsonPropertyName("prefixType")]
    public IPVersionConstant? PrefixType { get; set; }

    [JsonPropertyName("subnet")]
    public SubResourceModel? Subnet { get; set; }

    [JsonPropertyName("type")]
    public IPAllocationTypeConstant? Type { get; set; }

    [JsonPropertyName("virtualNetwork")]
    public SubResourceModel? VirtualNetwork { get; set; }
}
