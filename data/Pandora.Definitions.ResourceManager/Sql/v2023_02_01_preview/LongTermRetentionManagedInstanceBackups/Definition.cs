using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.LongTermRetentionManagedInstanceBackups;

internal class Definition : ResourceDefinition
{
    public string Name => "LongTermRetentionManagedInstanceBackups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new DeleteByResourceGroupOperation(),
        new GetOperation(),
        new GetByResourceGroupOperation(),
        new ListByDatabaseOperation(),
        new ListByInstanceOperation(),
        new ListByLocationOperation(),
        new ListByResourceGroupDatabaseOperation(),
        new ListByResourceGroupInstanceOperation(),
        new ListByResourceGroupLocationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupStorageRedundancyConstant),
        typeof(DatabaseStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceLongTermRetentionBackupModel),
        typeof(ManagedInstanceLongTermRetentionBackupPropertiesModel),
    };
}
