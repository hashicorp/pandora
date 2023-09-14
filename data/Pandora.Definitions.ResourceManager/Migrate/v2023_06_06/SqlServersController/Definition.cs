using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;

internal class Definition : ResourceDefinition
{
    public string Name => "SqlServersController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListBySqlSiteOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EsuStatusConstant),
        typeof(EsuYearConstant),
        typeof(FCIInstanceStateConstant),
        typeof(HealthErrorDetailsDiscoveryScopeConstant),
        typeof(MicrosoftAzureFDSWebRoleHealthErrorDetailsSourceConstant),
        typeof(ProvisioningStateConstant),
        typeof(SqlMachineOverviewFciRoleConstant),
        typeof(SqlServerStatusConstant),
        typeof(SupportStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorsModel),
        typeof(ProductSupportStatusModel),
        typeof(SqlFciPropertiesModel),
        typeof(SqlMachineOverviewModel),
        typeof(SqlServerPropertiesModel),
        typeof(SqlServerV2Model),
        typeof(SqlServerV2UpdateModel),
        typeof(SqlServerV2UpdatePropertiesModel),
    };
}
