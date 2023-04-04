using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.ProjectResource;

internal class Definition : ResourceDefinition
{
    public string Name => "ProjectResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProjectsCreateOrUpdateOperation(),
        new ProjectsDeleteOperation(),
        new ProjectsGetOperation(),
        new ProjectsListByResourceGroupOperation(),
        new ProjectsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProjectProvisioningStateConstant),
        typeof(ProjectSourcePlatformConstant),
        typeof(ProjectTargetPlatformConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionInfoModel),
        typeof(DatabaseInfoModel),
        typeof(ProjectModel),
        typeof(ProjectPropertiesModel),
    };
}
