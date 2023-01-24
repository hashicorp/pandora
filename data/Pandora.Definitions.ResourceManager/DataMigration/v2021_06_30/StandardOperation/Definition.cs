using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.StandardOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "StandardOperation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FilesCreateOrUpdateOperation(),
        new FilesDeleteOperation(),
        new FilesGetOperation(),
        new FilesListOperation(),
        new FilesReadOperation(),
        new FilesReadWriteOperation(),
        new FilesUpdateOperation(),
        new ProjectsCreateOrUpdateOperation(),
        new ProjectsDeleteOperation(),
        new ProjectsGetOperation(),
        new ProjectsListOperation(),
        new ProjectsUpdateOperation(),
        new ResourceSkusListSkusOperation(),
        new ServiceTasksCreateOrUpdateOperation(),
        new ServiceTasksDeleteOperation(),
        new ServiceTasksGetOperation(),
        new ServiceTasksListOperation(),
        new ServiceTasksUpdateOperation(),
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
