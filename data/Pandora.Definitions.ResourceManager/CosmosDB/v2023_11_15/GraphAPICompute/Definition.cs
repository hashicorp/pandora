using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_11_15.GraphAPICompute;

internal class Definition : ResourceDefinition
{
    public string Name => "GraphAPICompute";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServiceCreateOperation(),
        new ServiceDeleteOperation(),
        new ServiceGetOperation(),
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
        typeof(ServiceResourceCreateUpdateParametersModel),
        typeof(ServiceResourceCreateUpdatePropertiesModel),
        typeof(ServiceResourcePropertiesModel),
        typeof(SqlDedicatedGatewayRegionalServiceResourceModel),
        typeof(SqlDedicatedGatewayServiceResourcePropertiesModel),
    };
}
