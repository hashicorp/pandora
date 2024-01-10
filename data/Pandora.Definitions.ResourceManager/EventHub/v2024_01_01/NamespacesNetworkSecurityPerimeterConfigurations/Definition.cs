using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NamespacesNetworkSecurityPerimeterConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "NamespacesNetworkSecurityPerimeterConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NetworkSecurityPerimeterConfigurationListOperation(),
        new NetworkSecurityPerimeterConfigurationsCreateOrUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NetworkSecurityPerimeterConfigurationProvisioningStateConstant),
        typeof(NspAccessRuleDirectionConstant),
        typeof(ResourceAssociationAccessModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NetworkSecurityPerimeterModel),
        typeof(NetworkSecurityPerimeterConfigurationModel),
        typeof(NetworkSecurityPerimeterConfigurationListModel),
        typeof(NetworkSecurityPerimeterConfigurationPropertiesModel),
        typeof(NetworkSecurityPerimeterConfigurationPropertiesProfileModel),
        typeof(NetworkSecurityPerimeterConfigurationPropertiesResourceAssociationModel),
        typeof(NspAccessRuleModel),
        typeof(NspAccessRulePropertiesModel),
        typeof(NspAccessRulePropertiesSubscriptionsInlinedModel),
        typeof(ProvisioningIssueModel),
        typeof(ProvisioningIssuePropertiesModel),
    };
}
