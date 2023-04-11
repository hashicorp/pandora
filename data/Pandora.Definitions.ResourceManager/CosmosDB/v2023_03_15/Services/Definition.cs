using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.Services;

internal class Definition : ResourceDefinition
{
    public string Name => "Services";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServiceListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ServiceSizeConstant),
        typeof(ServiceStatusConstant),
        typeof(ServiceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataTransferServiceResourcePropertiesModel),
        typeof(GraphAPIComputeRegionalServiceResourceModel),
        typeof(GraphAPIComputeServiceResourcePropertiesModel),
        typeof(MaterializedViewsBuilderServiceResourcePropertiesModel),
        typeof(RegionalServiceResourceModel),
        typeof(ServiceResourceModel),
        typeof(ServiceResourceListResultModel),
        typeof(ServiceResourcePropertiesModel),
        typeof(SqlDedicatedGatewayRegionalServiceResourceModel),
        typeof(SqlDedicatedGatewayServiceResourcePropertiesModel),
    };
}
