using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2021_10_15.Restorables;

internal class Definition : ResourceDefinition
{
    public string Name => "Restorables";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MongoDBResourcesRetrieveContinuousBackupInformationOperation(),
        new RestorableDatabaseAccountsGetByLocationOperation(),
        new RestorableDatabaseAccountsListOperation(),
        new RestorableDatabaseAccountsListByLocationOperation(),
        new RestorableMongodbCollectionsListOperation(),
        new RestorableMongodbDatabasesListOperation(),
        new RestorableMongodbResourcesListOperation(),
        new RestorableSqlContainersListOperation(),
        new RestorableSqlDatabasesListOperation(),
        new RestorableSqlResourcesListOperation(),
        new SqlResourcesRetrieveContinuousBackupInformationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApiTypeConstant),
        typeof(CompositePathSortOrderConstant),
        typeof(ConflictResolutionModeConstant),
        typeof(DataTypeConstant),
        typeof(IndexKindConstant),
        typeof(IndexingModeConstant),
        typeof(OperationTypeConstant),
        typeof(PartitionKindConstant),
        typeof(SpatialTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupInformationModel),
        typeof(CompositePathModel),
        typeof(ConflictResolutionPolicyModel),
        typeof(ContainerPartitionKeyModel),
        typeof(ContinuousBackupInformationModel),
        typeof(ContinuousBackupRestoreLocationModel),
        typeof(DatabaseRestoreResourceModel),
        typeof(ExcludedPathModel),
        typeof(IncludedPathModel),
        typeof(IndexesModel),
        typeof(IndexingPolicyModel),
        typeof(RestorableDatabaseAccountGetResultModel),
        typeof(RestorableDatabaseAccountPropertiesModel),
        typeof(RestorableDatabaseAccountsListResultModel),
        typeof(RestorableLocationResourceModel),
        typeof(RestorableMongodbCollectionGetResultModel),
        typeof(RestorableMongodbCollectionPropertiesModel),
        typeof(RestorableMongodbCollectionPropertiesResourceModel),
        typeof(RestorableMongodbCollectionsListResultModel),
        typeof(RestorableMongodbDatabaseGetResultModel),
        typeof(RestorableMongodbDatabasePropertiesModel),
        typeof(RestorableMongodbDatabasePropertiesResourceModel),
        typeof(RestorableMongodbDatabasesListResultModel),
        typeof(RestorableMongodbResourcesListResultModel),
        typeof(RestorableSqlContainerGetResultModel),
        typeof(RestorableSqlContainerPropertiesModel),
        typeof(RestorableSqlContainerPropertiesResourceModel),
        typeof(RestorableSqlContainerPropertiesResourceContainerModel),
        typeof(RestorableSqlContainersListResultModel),
        typeof(RestorableSqlDatabaseGetResultModel),
        typeof(RestorableSqlDatabasePropertiesModel),
        typeof(RestorableSqlDatabasePropertiesResourceModel),
        typeof(RestorableSqlDatabasePropertiesResourceDatabaseModel),
        typeof(RestorableSqlDatabasesListResultModel),
        typeof(RestorableSqlResourcesListResultModel),
        typeof(SpatialSpecModel),
        typeof(UniqueKeyModel),
        typeof(UniqueKeyPolicyModel),
    };
}
