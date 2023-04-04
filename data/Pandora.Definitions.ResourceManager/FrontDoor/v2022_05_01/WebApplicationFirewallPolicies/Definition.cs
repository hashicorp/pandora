using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "WebApplicationFirewallPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PoliciesCreateOrUpdateOperation(),
        new PoliciesDeleteOperation(),
        new PoliciesGetOperation(),
        new PoliciesListOperation(),
        new PoliciesListBySubscriptionOperation(),
        new PoliciesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionTypeConstant),
        typeof(CustomRuleEnabledStateConstant),
        typeof(ManagedRuleEnabledStateConstant),
        typeof(ManagedRuleExclusionMatchVariableConstant),
        typeof(ManagedRuleExclusionSelectorMatchOperatorConstant),
        typeof(ManagedRuleSetActionTypeConstant),
        typeof(MatchVariableConstant),
        typeof(OperatorConstant),
        typeof(PolicyEnabledStateConstant),
        typeof(PolicyModeConstant),
        typeof(PolicyRequestBodyCheckConstant),
        typeof(PolicyResourceStateConstant),
        typeof(RuleTypeConstant),
        typeof(SkuNameConstant),
        typeof(TransformTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomRuleModel),
        typeof(CustomRuleListModel),
        typeof(FrontendEndpointLinkModel),
        typeof(ManagedRuleExclusionModel),
        typeof(ManagedRuleGroupOverrideModel),
        typeof(ManagedRuleOverrideModel),
        typeof(ManagedRuleSetModel),
        typeof(ManagedRuleSetListModel),
        typeof(MatchConditionModel),
        typeof(PolicySettingsModel),
        typeof(RoutingRuleLinkModel),
        typeof(SecurityPolicyLinkModel),
        typeof(SkuModel),
        typeof(TagsObjectModel),
        typeof(WebApplicationFirewallPolicyModel),
        typeof(WebApplicationFirewallPolicyPropertiesModel),
    };
}
