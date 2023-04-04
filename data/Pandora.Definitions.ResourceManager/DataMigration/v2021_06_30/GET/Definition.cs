using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.GET;

internal class Definition : ResourceDefinition
{
    public string Name => "GET";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FilesGetOperation(),
        new FilesListOperation(),
        new ProjectsGetOperation(),
        new ProjectsListOperation(),
        new ResourceSkusListSkusOperation(),
        new ServiceTasksGetOperation(),
        new ServiceTasksListOperation(),
        new ServicesGetOperation(),
        new ServicesListOperation(),
        new ServicesListByResourceGroupOperation(),
        new ServicesListSkusOperation(),
        new TasksGetOperation(),
        new TasksListOperation(),
        new UsagesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommandStateConstant),
        typeof(ProjectProvisioningStateConstant),
        typeof(ProjectSourcePlatformConstant),
        typeof(ProjectTargetPlatformConstant),
        typeof(ResourceSkuCapacityScaleTypeConstant),
        typeof(ResourceSkuRestrictionsReasonCodeConstant),
        typeof(ResourceSkuRestrictionsTypeConstant),
        typeof(ServiceProvisioningStateConstant),
        typeof(ServiceScalabilityConstant),
        typeof(TaskStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailableServiceSkuModel),
        typeof(AvailableServiceSkuCapacityModel),
        typeof(AvailableServiceSkuSkuModel),
        typeof(CommandPropertiesModel),
        typeof(ConnectionInfoModel),
        typeof(DataMigrationServiceModel),
        typeof(DataMigrationServicePropertiesModel),
        typeof(DatabaseInfoModel),
        typeof(ODataErrorModel),
        typeof(ProjectModel),
        typeof(ProjectFileModel),
        typeof(ProjectFilePropertiesModel),
        typeof(ProjectPropertiesModel),
        typeof(ProjectTaskModel),
        typeof(ProjectTaskPropertiesModel),
        typeof(QuotaModel),
        typeof(QuotaNameModel),
        typeof(ResourceSkuModel),
        typeof(ResourceSkuCapabilitiesModel),
        typeof(ResourceSkuCapacityModel),
        typeof(ResourceSkuCostsModel),
        typeof(ResourceSkuRestrictionsModel),
        typeof(ServiceSkuModel),
    };
}
