using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlDatabasesController;

internal class Definition : ResourceDefinition
{
    public string Name => "SqlDatabasesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListBySqlSiteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FileTypeConstant),
        typeof(HealthErrorDetailsDiscoveryScopeConstant),
        typeof(MicrosoftAzureFDSWebRoleHealthErrorDetailsSourceConstant),
        typeof(ProvisioningStateConstant),
        typeof(SqlAvailabilityReplicaOverviewReplicaStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorsModel),
        typeof(FileMetaDataModel),
        typeof(SqlAvailabilityReplicaOverviewModel),
        typeof(SqlDatabasePropertiesV2Model),
        typeof(SqlDatabaseV2Model),
    };
}
