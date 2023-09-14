using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ServerSoftwareInventoriesController;

internal class Definition : ResourceDefinition
{
    public string Name => "ServerSoftwareInventoriesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetMachineSoftwareInventoryOperation(),
        new ListByServerOperation(),
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
        typeof(MachineSoftwareInventoryPropertiesModel),
        typeof(OtherDatabaseModel),
        typeof(ServerSoftwareInventoryModel),
        typeof(SharePointServerModel),
        typeof(SqlServerApplicationModel),
        typeof(SystemCenterModel),
        typeof(WebApplicationAppsAndRolesModelModel),
    };
}
