using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ApplicationGatewayWafDynamicManifests;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationGatewayWafDynamicManifests";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DefaultGetOperation(),
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationGatewayRuleSetStatusOptionsConstant),
        typeof(ApplicationGatewayTierTypesConstant),
        typeof(ApplicationGatewayWafRuleActionTypesConstant),
        typeof(ApplicationGatewayWafRuleStateTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationGatewayFirewallManifestRuleSetModel),
        typeof(ApplicationGatewayFirewallRuleModel),
        typeof(ApplicationGatewayFirewallRuleGroupModel),
        typeof(ApplicationGatewayWafDynamicManifestPropertiesResultModel),
        typeof(ApplicationGatewayWafDynamicManifestResultModel),
        typeof(DefaultRuleSetPropertyFormatModel),
    };
}
