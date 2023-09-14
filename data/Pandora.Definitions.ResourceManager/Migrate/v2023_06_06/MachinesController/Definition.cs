using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MachinesController;

internal class Definition : ResourceDefinition
{
    public string Name => "MachinesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByVMwareSiteOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationDiscoveryScopeStatusConstant),
        typeof(DependencyMapDiscoveryScopeStatusConstant),
        typeof(DiscoveryScopeStatusConstant),
        typeof(EsuStatusConstant),
        typeof(EsuYearConstant),
        typeof(HealthErrorDetailsDiscoveryScopeConstant),
        typeof(HealthErrorDetailsSourceConstant),
        typeof(ProvisioningStateConstant),
        typeof(SQLDiscoveryScopeStatusConstant),
        typeof(ShallowDiscoveryStatusConstant),
        typeof(SqlMetadataDiscoveryPipeConstant),
        typeof(StaticDiscoveryScopeStatusConstant),
        typeof(SupportStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationModel),
        typeof(ApplicationDiscoveryModel),
        typeof(AppsAndRolesModel),
        typeof(BizTalkServerModel),
        typeof(DependencyMapDiscoveryModel),
        typeof(ExchangeServerModel),
        typeof(FeatureModel),
        typeof(GuestOsDetailsModel),
        typeof(HealthErrorDetailsModel),
        typeof(MachineResourceModel),
        typeof(MachineResourceUpdateModel),
        typeof(MachineResourceUpdatePropertiesModel),
        typeof(OperatingSystemModel),
        typeof(OracleDiscoveryModel),
        typeof(OtherDatabaseModel),
        typeof(ProductSupportStatusModel),
        typeof(SharePointServerModel),
        typeof(SpringBootDiscoveryModel),
        typeof(SqlDiscoveryModel),
        typeof(SqlServerApplicationModel),
        typeof(StaticDiscoveryModel),
        typeof(SystemCenterModel),
        typeof(VMwareDiskModel),
        typeof(VMwareMachinePropertiesModel),
        typeof(VMwareNetworkAdapterModel),
        typeof(WebAppDiscoveryModel),
        typeof(WebApplicationAppsAndRolesModelModel),
    };
}
