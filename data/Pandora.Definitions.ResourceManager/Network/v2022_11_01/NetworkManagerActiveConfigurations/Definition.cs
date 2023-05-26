using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.NetworkManagerActiveConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkManagerActiveConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListActiveSecurityAdminRulesOperation(),
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
        typeof(ActiveBaseSecurityAdminRuleModel),
        typeof(ActiveConfigurationParameterModel),
        typeof(ActiveDefaultSecurityAdminRuleModel),
        typeof(ActiveSecurityAdminRuleModel),
        typeof(ActiveSecurityAdminRulesListResultModel),
        typeof(AddressPrefixItemModel),
        typeof(AdminPropertiesFormatModel),
        typeof(ConfigurationGroupModel),
        typeof(DefaultAdminPropertiesFormatModel),
        typeof(NetworkGroupPropertiesModel),
        typeof(NetworkManagerSecurityGroupItemModel),
    };
}
