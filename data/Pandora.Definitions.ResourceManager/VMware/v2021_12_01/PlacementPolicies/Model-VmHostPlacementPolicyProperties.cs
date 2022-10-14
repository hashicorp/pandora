using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.PlacementPolicies;

[ValueForType("VmHost")]
internal class VmHostPlacementPolicyPropertiesModel : PlacementPolicyPropertiesModel
{
    [JsonPropertyName("affinityType")]
    [Required]
    public AffinityTypeConstant AffinityType { get; set; }

    [JsonPropertyName("hostMembers")]
    [Required]
    public List<string> HostMembers { get; set; }

    [JsonPropertyName("vmMembers")]
    [Required]
    public List<string> VmMembers { get; set; }
}
