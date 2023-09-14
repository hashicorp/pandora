using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;

internal class Definition : ResourceDefinition
{
    public string Name => "SqlAvailabilityGroupsController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListBySqlSiteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(SqlAvailabilityGroupPropertiesAvailabilityGroupTypeConstant),
        typeof(SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaCommitModeConstant),
        typeof(SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaReadModeConstant),
        typeof(SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaSeedModeConstant),
        typeof(SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaStateConstant),
        typeof(SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaSyncStatusConstant),
        typeof(SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaTypeConstant),
        typeof(SqlAvailabilityReplicaOverviewReplicaStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SqlAvailabilityGroupModel),
        typeof(SqlAvailabilityGroupPropertiesModel),
        typeof(SqlAvailabilityGroupReplicaInfoModel),
        typeof(SqlAvailabilityReplicaOverviewModel),
        typeof(SqlAvailabilityReplicaPropertiesModel),
        typeof(SqlDatabaseReplicaInfoModel),
    };
}
