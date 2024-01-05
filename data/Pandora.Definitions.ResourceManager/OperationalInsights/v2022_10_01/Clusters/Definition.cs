using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BillingTypeConstant),
        typeof(CapacityConstant),
        typeof(ClusterEntityStatusConstant),
        typeof(ClusterSkuNameEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssociatedWorkspaceModel),
        typeof(CapacityReservationPropertiesModel),
        typeof(ClusterModel),
        typeof(ClusterPatchModel),
        typeof(ClusterPatchPropertiesModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterSkuModel),
        typeof(KeyVaultPropertiesModel),
    };
}
