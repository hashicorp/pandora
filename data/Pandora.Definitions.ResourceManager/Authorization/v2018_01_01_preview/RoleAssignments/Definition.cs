using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2018_01_01_preview.RoleAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new CreateByIdOperation(),
        new DeleteOperation(),
        new DeleteByIdOperation(),
        new GetOperation(),
        new GetByIdOperation(),
        new ListOperation(),
        new ListForResourceOperation(),
        new ListForResourceGroupOperation(),
        new ListForScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RoleAssignmentModel),
        typeof(RoleAssignmentCreateParametersModel),
        typeof(RoleAssignmentPropertiesModel),
        typeof(RoleAssignmentPropertiesWithScopeModel),
    };
}
