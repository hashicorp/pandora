using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.Firewalls;


internal class VwanConfigurationModel
{
    [JsonPropertyName("ipOfTrustSubnetForUdr")]
    public IPAddressModel? IPOfTrustSubnetForUdr { get; set; }

    [JsonPropertyName("networkVirtualApplianceId")]
    public string? NetworkVirtualApplianceId { get; set; }

    [JsonPropertyName("trustSubnet")]
    public IPAddressSpaceModel? TrustSubnet { get; set; }

    [JsonPropertyName("unTrustSubnet")]
    public IPAddressSpaceModel? UnTrustSubnet { get; set; }

    [JsonPropertyName("vHub")]
    [Required]
    public IPAddressSpaceModel VHub { get; set; }
}
