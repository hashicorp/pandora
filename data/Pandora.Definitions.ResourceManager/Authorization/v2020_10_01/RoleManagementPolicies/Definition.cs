using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new ListForScopeOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RoleManagementPolicyRuleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PolicyPropertiesModel),
        typeof(PolicyPropertiesScopeModel),
        typeof(PrincipalModel),
        typeof(RoleManagementPolicyModel),
        typeof(RoleManagementPolicyPropertiesModel),
        typeof(RoleManagementPolicyRuleModel),
        typeof(RoleManagementPolicyRuleTargetModel),
    };
}
