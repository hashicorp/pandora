using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.RestorePoints;

internal class Definition : ResourceDefinition
{
    public string Name => "RestorePoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDatabaseOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RestorePointTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateDatabaseRestorePointDefinitionModel),
        typeof(RestorePointModel),
        typeof(RestorePointListResultModel),
        typeof(RestorePointPropertiesModel),
    };
}
