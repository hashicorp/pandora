using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "HyperVMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetAllMachinesInSiteOperation(),
        new GetMachineOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HighlyAvailableConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationModel),
        typeof(AppsAndRolesModel),
        typeof(BizTalkServerModel),
        typeof(ExchangeServerModel),
        typeof(FeatureModel),
        typeof(GuestOSDetailsModel),
        typeof(HealthErrorDetailsModel),
        typeof(HyperVDiskModel),
        typeof(HyperVMachineModel),
        typeof(HyperVMachinePropertiesModel),
        typeof(HyperVNetworkAdapterModel),
        typeof(OperatingSystemModel),
        typeof(OtherDatabaseModel),
        typeof(SQLServerModel),
        typeof(SharePointServerModel),
        typeof(SystemCenterModel),
        typeof(WebApplicationModel),
    };
}
