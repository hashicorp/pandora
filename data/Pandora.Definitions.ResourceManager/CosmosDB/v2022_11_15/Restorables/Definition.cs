using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.Restorables;

internal class Definition : ResourceDefinition
{
    public string Name => "Restorables";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GremlinResourcesRetrieveContinuousBackupInformationOperation(),
        new MongoDBResourcesRetrieveContinuousBackupInformationOperation(),
        new RestorableDatabaseAccountsGetByLocationOperation(),
        new RestorableDatabaseAccountsListOperation(),
        new RestorableDatabaseAccountsListByLocationOperation(),
        new RestorableGremlinDatabasesListOperation(),
        new RestorableGremlinGraphsListOperation(),
        new RestorableGremlinResourcesListOperation(),
        new RestorableMongodbCollectionsListOperation(),
        new RestorableMongodbDatabasesListOperation(),
        new RestorableMongodbResourcesListOperation(),
        new RestorableSqlContainersListOperation(),
        new RestorableSqlDatabasesListOperation(),
        new RestorableSqlResourcesListOperation(),
        new RestorableTableResourcesListOperation(),
        new RestorableTablesListOperation(),
        new SqlResourcesRetrieveContinuousBackupInformationOperation(),
        new TableResourcesRetrieveContinuousBackupInformationOperation(),
    };
}
