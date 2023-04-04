using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.Machines;

internal class Definition : ResourceDefinition
{
    public string Name => "Machines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetAllMachinesInSiteOperation(),
        new GetMachineOperation(),
        new StartMachineOperation(),
        new StopMachineOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(VirtualDiskModeConstant),
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
        typeof(OperatingSystemModel),
        typeof(OtherDatabaseModel),
        typeof(SQLServerModel),
        typeof(SharePointServerModel),
        typeof(SystemCenterModel),
        typeof(VMwareDiskModel),
        typeof(VMwareMachineModel),
        typeof(VMwareMachinePropertiesModel),
        typeof(VMwareNetworkAdapterModel),
        typeof(WebApplicationModel),
    };
}
