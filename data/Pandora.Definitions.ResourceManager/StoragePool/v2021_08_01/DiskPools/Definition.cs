using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools;

internal class Definition : ResourceDefinition
{
    public string Name => "DiskPools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeallocateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListOutboundNetworkDependenciesEndpointsOperation(),
        new StartOperation(),
        new UpdateOperation(),
        new UpgradeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationalStatusConstant),
        typeof(ProvisioningStatesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiskModel),
        typeof(DiskPoolModel),
        typeof(DiskPoolCreateModel),
        typeof(DiskPoolCreatePropertiesModel),
        typeof(DiskPoolPropertiesModel),
        typeof(DiskPoolUpdateModel),
        typeof(DiskPoolUpdatePropertiesModel),
        typeof(EndpointDependencyModel),
        typeof(EndpointDetailModel),
        typeof(OutboundEnvironmentEndpointModel),
        typeof(SkuModel),
    };
}
