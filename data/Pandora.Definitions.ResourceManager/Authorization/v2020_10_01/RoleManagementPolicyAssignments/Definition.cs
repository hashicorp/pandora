using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicyAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleManagementPolicyAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListForScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RoleManagementPolicyRuleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PolicyAssignmentPropertiesModel),
        typeof(PolicyAssignmentPropertiesPolicyModel),
        typeof(PolicyAssignmentPropertiesRoleDefinitionModel),
        typeof(PolicyAssignmentPropertiesScopeModel),
        typeof(PrincipalModel),
        typeof(RoleManagementPolicyAssignmentModel),
        typeof(RoleManagementPolicyAssignmentPropertiesModel),
        typeof(RoleManagementPolicyRuleModel),
        typeof(RoleManagementPolicyRuleTargetModel),
    };
}
