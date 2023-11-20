using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NetworkRuleSets;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkRuleSets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCreateOrUpdateNetworkRuleSetOperation(),
        new NamespacesGetNetworkRuleSetOperation(),
        new NamespacesListNetworkRuleSetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DefaultActionConstant),
        typeof(NetworkRuleIPActionConstant),
        typeof(PublicNetworkAccessFlagConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NWRuleSetIPRulesModel),
        typeof(NWRuleSetVirtualNetworkRulesModel),
        typeof(NetworkRuleSetModel),
        typeof(NetworkRuleSetListResultModel),
        typeof(NetworkRuleSetPropertiesModel),
        typeof(SubnetModel),
    };
}
