using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.StandardOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "StandardOperation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProjectsCreateOrUpdateOperation(),
        new ProjectsDeleteOperation(),
        new ProjectsGetOperation(),
        new ProjectsListByResourceGroupOperation(),
        new ProjectsUpdateOperation(),
        new ResourceSkusListSkusOperation(),
        new ServicesCheckNameAvailabilityOperation(),
        new ServicesCreateOrUpdateOperation(),
        new ServicesDeleteOperation(),
        new ServicesGetOperation(),
        new ServicesListOperation(),
        new ServicesListByResourceGroupOperation(),
        new ServicesListSkusOperation(),
        new ServicesUpdateOperation(),
        new TasksCreateOrUpdateOperation(),
        new TasksDeleteOperation(),
        new TasksGetOperation(),
        new TasksListOperation(),
        new TasksUpdateOperation(),
        new UsagesListOperation(),
    };
}
