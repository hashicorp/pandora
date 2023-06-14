using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;


internal class VnetConfigurationModel
{
    [JsonPropertyName("ipOfTrustSubnetForUdr")]
    public IPAddressModel? IPOfTrustSubnetForUdr { get; set; }

    [JsonPropertyName("trustSubnet")]
    [Required]
    public IPAddressSpaceModel TrustSubnet { get; set; }

    [JsonPropertyName("unTrustSubnet")]
    [Required]
    public IPAddressSpaceModel UnTrustSubnet { get; set; }

    [JsonPropertyName("vnet")]
    [Required]
    public IPAddressSpaceModel Vnet { get; set; }
}
