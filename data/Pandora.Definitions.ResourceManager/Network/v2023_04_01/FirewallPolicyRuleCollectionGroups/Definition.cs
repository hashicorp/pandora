using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.FirewallPolicyRuleCollectionGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "FirewallPolicyRuleCollectionGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FirewallPolicyFilterRuleCollectionActionTypeConstant),
        typeof(FirewallPolicyNatRuleCollectionActionTypeConstant),
        typeof(FirewallPolicyRuleApplicationProtocolTypeConstant),
        typeof(FirewallPolicyRuleCollectionTypeConstant),
        typeof(FirewallPolicyRuleNetworkProtocolConstant),
        typeof(FirewallPolicyRuleTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationRuleModel),
        typeof(FirewallPolicyFilterRuleCollectionModel),
        typeof(FirewallPolicyFilterRuleCollectionActionModel),
        typeof(FirewallPolicyHTTPHeaderToInsertModel),
        typeof(FirewallPolicyNatRuleCollectionModel),
        typeof(FirewallPolicyNatRuleCollectionActionModel),
        typeof(FirewallPolicyRuleModel),
        typeof(FirewallPolicyRuleApplicationProtocolModel),
        typeof(FirewallPolicyRuleCollectionModel),
        typeof(FirewallPolicyRuleCollectionGroupModel),
        typeof(FirewallPolicyRuleCollectionGroupPropertiesModel),
        typeof(NatRuleModel),
        typeof(NetworkRuleModel),
    };
}
