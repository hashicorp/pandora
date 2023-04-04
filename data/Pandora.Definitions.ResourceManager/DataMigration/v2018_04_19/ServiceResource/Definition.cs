using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.ServiceResource;

internal class Definition : ResourceDefinition
{
    public string Name => "ServiceResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServicesCheckStatusOperation(),
        new ServicesCreateOrUpdateOperation(),
        new ServicesDeleteOperation(),
        new ServicesGetOperation(),
        new ServicesListOperation(),
        new ServicesListByResourceGroupOperation(),
        new ServicesListSkusOperation(),
        new ServicesStartOperation(),
        new ServicesStopOperation(),
        new ServicesUpdateOperation(),
        new TasksListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommandStateConstant),
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
        typeof(DataMigrationServiceModel),
        typeof(DataMigrationServicePropertiesModel),
        typeof(DataMigrationServiceStatusResponseModel),
        typeof(ODataErrorModel),
        typeof(ProjectTaskModel),
        typeof(ProjectTaskPropertiesModel),
        typeof(ServiceSkuModel),
    };
}
