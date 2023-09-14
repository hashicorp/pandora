using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervSoftwareInventoriesController;

internal class Definition : ResourceDefinition
{
    public string Name => "HypervSoftwareInventoriesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetMachineSoftwareInventoryOperation(),
        new ListByHypervMachineOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationModel),
        typeof(AppsAndRolesModel),
        typeof(BizTalkServerModel),
        typeof(ExchangeServerModel),
        typeof(FeatureModel),
        typeof(HypervVMSoftwareInventoryModel),
        typeof(MachineSoftwareInventoryPropertiesModel),
        typeof(OtherDatabaseModel),
        typeof(SharePointServerModel),
        typeof(SqlServerApplicationModel),
        typeof(SystemCenterModel),
        typeof(WebApplicationAppsAndRolesModelModel),
    };
}
