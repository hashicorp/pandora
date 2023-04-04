using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusterSnapshots;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedClusterSnapshots";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LoadBalancerSkuConstant),
        typeof(ManagedClusterSKUNameConstant),
        typeof(ManagedClusterSKUTierConstant),
        typeof(NetworkModeConstant),
        typeof(NetworkPluginConstant),
        typeof(NetworkPluginModeConstant),
        typeof(NetworkPolicyConstant),
        typeof(SnapshotTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreationDataModel),
        typeof(ManagedClusterPropertiesForSnapshotModel),
        typeof(ManagedClusterSKUModel),
        typeof(ManagedClusterSnapshotModel),
        typeof(ManagedClusterSnapshotPropertiesModel),
        typeof(NetworkProfileForSnapshotModel),
        typeof(TagsObjectModel),
    };
}
