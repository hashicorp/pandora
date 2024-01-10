using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "SyncGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelSyncOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDatabaseOperation(),
        new ListHubSchemasOperation(),
        new ListLogsOperation(),
        new ListSyncDatabaseIdsOperation(),
        new RefreshHubSchemaOperation(),
        new TriggerSyncOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SyncConflictResolutionPolicyConstant),
        typeof(SyncGroupLogTypeConstant),
        typeof(SyncGroupStateConstant),
        typeof(SyncGroupsTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SkuModel),
        typeof(SyncDatabaseIdPropertiesModel),
        typeof(SyncFullSchemaPropertiesModel),
        typeof(SyncFullSchemaTableModel),
        typeof(SyncFullSchemaTableColumnModel),
        typeof(SyncGroupModel),
        typeof(SyncGroupLogPropertiesModel),
        typeof(SyncGroupPropertiesModel),
        typeof(SyncGroupSchemaModel),
        typeof(SyncGroupSchemaTableModel),
        typeof(SyncGroupSchemaTableColumnModel),
    };
}
