using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualNetworks;


internal class SubnetOverrideModel
{
    [JsonPropertyName("labSubnetName")]
    public string? LabSubnetName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("sharedPublicIpAddressConfiguration")]
    public SubnetSharedPublicIPAddressConfigurationModel? SharedPublicIPAddressConfiguration { get; set; }

    [JsonPropertyName("useInVmCreationPermission")]
    public UsagePermissionTypeConstant? UseInVMCreationPermission { get; set; }

    [JsonPropertyName("usePublicIpAddressPermission")]
    public UsagePermissionTypeConstant? UsePublicIPAddressPermission { get; set; }

    [JsonPropertyName("virtualNetworkPoolName")]
    public string? VirtualNetworkPoolName { get; set; }
}
