using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabases;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedDatabases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelMoveOperation(),
        new CompleteMoveOperation(),
        new CompleteRestoreOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByInstanceOperation(),
        new ListInaccessibleByInstanceOperation(),
        new StartMoveOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CatalogCollationTypeConstant),
        typeof(ManagedDatabaseCreateModeConstant),
        typeof(ManagedDatabaseStatusConstant),
        typeof(MoveOperationModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CompleteDatabaseRestoreDefinitionModel),
        typeof(ManagedDatabaseModel),
        typeof(ManagedDatabaseMoveDefinitionModel),
        typeof(ManagedDatabasePropertiesModel),
        typeof(ManagedDatabaseStartMoveDefinitionModel),
        typeof(ManagedDatabaseUpdateModel),
    };
}
