using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.IPGroups;


internal class IPGroupPropertiesFormatModel
{
    [JsonPropertyName("firewallPolicies")]
    public List<SubResourceModel>? FirewallPolicies { get; set; }

    [JsonPropertyName("firewalls")]
    public List<SubResourceModel>? Firewalls { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
