using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.P2SVpnGateways;


internal class VpnServerConfigurationPolicyGroupMemberModel
{
    [JsonPropertyName("attributeType")]
    public VpnPolicyMemberAttributeTypeConstant? AttributeType { get; set; }

    [JsonPropertyName("attributeValue")]
    public string? AttributeValue { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
