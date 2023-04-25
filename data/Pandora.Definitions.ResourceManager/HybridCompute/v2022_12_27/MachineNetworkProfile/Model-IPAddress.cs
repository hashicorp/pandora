using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.MachineNetworkProfile;


internal class IPAddressModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("ipAddressVersion")]
    public string? IPAddressVersion { get; set; }

    [JsonPropertyName("subnet")]
    public SubnetModel? Subnet { get; set; }
}
