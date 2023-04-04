using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleEligibilitySchedules;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleEligibilitySchedules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListForScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MemberTypeConstant),
        typeof(PrincipalTypeConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpandedPropertiesModel),
        typeof(ExpandedPropertiesPrincipalModel),
        typeof(ExpandedPropertiesRoleDefinitionModel),
        typeof(ExpandedPropertiesScopeModel),
        typeof(RoleEligibilityScheduleModel),
        typeof(RoleEligibilitySchedulePropertiesModel),
    };
}
