using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.P2SVpnGateways;


internal class VpnServerConfigurationPolicyGroupPropertiesModel
{
    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("p2SConnectionConfigurations")]
    public List<SubResourceModel>? P2SConnectionConfigurations { get; set; }

    [JsonPropertyName("policyMembers")]
    public List<VpnServerConfigurationPolicyGroupMemberModel>? PolicyMembers { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
