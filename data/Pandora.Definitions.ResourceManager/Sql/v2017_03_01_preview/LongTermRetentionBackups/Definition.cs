using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.LongTermRetentionBackups;

internal class Definition : ResourceDefinition
{
    public string Name => "LongTermRetentionBackups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new DeleteByResourceGroupOperation(),
        new GetOperation(),
        new GetByResourceGroupOperation(),
        new ListByDatabaseOperation(),
        new ListByLocationOperation(),
        new ListByResourceGroupDatabaseOperation(),
        new ListByResourceGroupLocationOperation(),
        new ListByResourceGroupServerOperation(),
        new ListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LongTermRetentionDatabaseStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LongTermRetentionBackupModel),
        typeof(LongTermRetentionBackupPropertiesModel),
    };
}
