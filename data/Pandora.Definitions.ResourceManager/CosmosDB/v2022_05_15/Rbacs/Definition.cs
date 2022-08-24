using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.Rbacs;

internal class Definition : ResourceDefinition
{
    public string Name => "Rbacs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SqlResourcesCreateUpdateSqlRoleAssignmentOperation(),
        new SqlResourcesCreateUpdateSqlRoleDefinitionOperation(),
        new SqlResourcesDeleteSqlRoleAssignmentOperation(),
        new SqlResourcesDeleteSqlRoleDefinitionOperation(),
        new SqlResourcesGetSqlRoleAssignmentOperation(),
        new SqlResourcesGetSqlRoleDefinitionOperation(),
        new SqlResourcesListSqlRoleAssignmentsOperation(),
        new SqlResourcesListSqlRoleDefinitionsOperation(),
    };
}
