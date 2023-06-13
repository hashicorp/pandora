using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.ManagedDatabases;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedDatabases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CompleteRestoreOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByInstanceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CatalogCollationTypeConstant),
        typeof(ManagedDatabaseCreateModeConstant),
        typeof(ManagedDatabaseStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CompleteDatabaseRestoreDefinitionModel),
        typeof(ManagedDatabaseModel),
        typeof(ManagedDatabasePropertiesModel),
        typeof(ManagedDatabaseUpdateModel),
    };
}
