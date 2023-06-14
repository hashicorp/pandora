using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkManagerEffectiveSecurityAdminRules;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkManagerEffectiveSecurityAdminRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListNetworkManagerEffectiveSecurityAdminRulesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AddressPrefixTypeConstant),
        typeof(EffectiveAdminRuleKindConstant),
        typeof(ProvisioningStateConstant),
        typeof(SecurityConfigurationRuleAccessConstant),
        typeof(SecurityConfigurationRuleDirectionConstant),
        typeof(SecurityConfigurationRuleProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressPrefixItemModel),
        typeof(AdminPropertiesFormatModel),
        typeof(ConfigurationGroupModel),
        typeof(DefaultAdminPropertiesFormatModel),
        typeof(EffectiveBaseSecurityAdminRuleModel),
        typeof(EffectiveDefaultSecurityAdminRuleModel),
        typeof(EffectiveSecurityAdminRuleModel),
        typeof(NetworkGroupPropertiesModel),
        typeof(NetworkManagerEffectiveSecurityAdminRulesListResultModel),
        typeof(NetworkManagerSecurityGroupItemModel),
        typeof(QueryRequestOptionsModel),
    };
}
