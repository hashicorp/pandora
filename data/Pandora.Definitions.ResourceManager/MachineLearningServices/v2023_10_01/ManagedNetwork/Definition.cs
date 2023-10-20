using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.ManagedNetwork;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedNetwork";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProvisionsProvisionManagedNetworkOperation(),
        new SettingsRuleCreateOrUpdateOperation(),
        new SettingsRuleDeleteOperation(),
        new SettingsRuleGetOperation(),
        new SettingsRuleListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ManagedNetworkStatusConstant),
        typeof(RuleActionConstant),
        typeof(RuleCategoryConstant),
        typeof(RuleStatusConstant),
        typeof(RuleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FqdnOutboundRuleModel),
        typeof(ManagedNetworkProvisionOptionsModel),
        typeof(ManagedNetworkProvisionStatusModel),
        typeof(OutboundRuleModel),
        typeof(OutboundRuleBasicResourceModel),
        typeof(PrivateEndpointDestinationModel),
        typeof(PrivateEndpointOutboundRuleModel),
        typeof(ServiceTagDestinationModel),
        typeof(ServiceTagOutboundRuleModel),
    };
}
