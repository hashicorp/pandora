using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.PUT;

internal class Definition : ResourceDefinition
{
    public string Name => "PUT";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProjectsCreateOrUpdateOperation(),
        new ServicesCreateOrUpdateOperation(),
        new TasksCreateOrUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommandStateConstant),
        typeof(ProjectProvisioningStateConstant),
        typeof(ProjectSourcePlatformConstant),
        typeof(ProjectTargetPlatformConstant),
        typeof(ServiceProvisioningStateConstant),
        typeof(TaskStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommandPropertiesModel),
        typeof(ConnectionInfoModel),
        typeof(DataMigrationServiceModel),
        typeof(DataMigrationServicePropertiesModel),
        typeof(DatabaseInfoModel),
        typeof(ODataErrorModel),
        typeof(ProjectModel),
        typeof(ProjectPropertiesModel),
        typeof(ProjectTaskModel),
        typeof(ProjectTaskPropertiesModel),
        typeof(ServiceSkuModel),
    };
}
