using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.AdminRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AdminRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AddressPrefixTypeConstant),
        typeof(AdminRuleKindConstant),
        typeof(ProvisioningStateConstant),
        typeof(SecurityConfigurationRuleAccessConstant),
        typeof(SecurityConfigurationRuleDirectionConstant),
        typeof(SecurityConfigurationRuleProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressPrefixItemModel),
        typeof(AdminPropertiesFormatModel),
        typeof(AdminRuleModel),
        typeof(BaseAdminRuleModel),
        typeof(DefaultAdminPropertiesFormatModel),
        typeof(DefaultAdminRuleModel),
    };
}
