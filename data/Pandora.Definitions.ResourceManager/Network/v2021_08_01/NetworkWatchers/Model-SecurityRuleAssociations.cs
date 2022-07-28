using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;


internal class SecurityRuleAssociationsModel
{
    [JsonPropertyName("defaultSecurityRules")]
    public List<SecurityRuleModel>? DefaultSecurityRules { get; set; }

    [JsonPropertyName("effectiveSecurityRules")]
    public List<EffectiveNetworkSecurityRuleModel>? EffectiveSecurityRules { get; set; }

    [JsonPropertyName("networkInterfaceAssociation")]
    public NetworkInterfaceAssociationModel? NetworkInterfaceAssociation { get; set; }

    [JsonPropertyName("subnetAssociation")]
    public SubnetAssociationModel? SubnetAssociation { get; set; }
}
