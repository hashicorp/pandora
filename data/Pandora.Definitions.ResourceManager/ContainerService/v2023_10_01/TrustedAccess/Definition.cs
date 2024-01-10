using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.TrustedAccess;

internal class Definition : ResourceDefinition
{
    public string Name => "TrustedAccess";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RoleBindingsCreateOrUpdateOperation(),
        new RoleBindingsDeleteOperation(),
        new RoleBindingsGetOperation(),
        new RoleBindingsListOperation(),
        new RolesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TrustedAccessRoleBindingProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TrustedAccessRoleModel),
        typeof(TrustedAccessRoleBindingModel),
        typeof(TrustedAccessRoleBindingPropertiesModel),
        typeof(TrustedAccessRoleRuleModel),
    };
}
