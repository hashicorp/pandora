using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.GET;

internal class Definition : ResourceDefinition
{
    public string Name => "GET";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProjectsGetOperation(),
        new ProjectsListByResourceGroupOperation(),
        new ResourceSkusListSkusOperation(),
        new ServicesGetOperation(),
        new ServicesListOperation(),
        new ServicesListByResourceGroupOperation(),
        new ServicesListSkusOperation(),
        new TasksGetOperation(),
        new TasksListOperation(),
        new UsagesListOperation(),
    };
}
