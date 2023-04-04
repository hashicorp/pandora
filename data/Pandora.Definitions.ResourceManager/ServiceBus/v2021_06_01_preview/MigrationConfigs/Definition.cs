using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.MigrationConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "MigrationConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CompleteMigrationOperation(),
        new CreateAndStartMigrationOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new RevertOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MigrationConfigPropertiesModel),
        typeof(MigrationConfigPropertiesPropertiesModel),
    };
}
