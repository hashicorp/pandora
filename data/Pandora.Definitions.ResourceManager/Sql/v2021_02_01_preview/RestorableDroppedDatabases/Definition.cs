using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.RestorableDroppedDatabases;

internal class Definition : ResourceDefinition
{
    public string Name => "RestorableDroppedDatabases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupStorageRedundancyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RestorableDroppedDatabaseModel),
        typeof(RestorableDroppedDatabasePropertiesModel),
        typeof(SkuModel),
    };
}
