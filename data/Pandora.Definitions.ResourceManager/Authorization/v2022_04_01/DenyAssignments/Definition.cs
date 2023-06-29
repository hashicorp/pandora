using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.DenyAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "DenyAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
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
        typeof(DenyAssignmentModel),
        typeof(DenyAssignmentPermissionModel),
        typeof(DenyAssignmentPropertiesModel),
        typeof(PrincipalModel),
    };
}
