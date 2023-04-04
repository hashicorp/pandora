using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "EventHubsClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClustersCreateOrUpdateOperation(),
        new ClustersDeleteOperation(),
        new ClustersGetOperation(),
        new ClustersListByResourceGroupOperation(),
        new ClustersListBySubscriptionOperation(),
        new ClustersUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClusterSkuNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterSkuModel),
    };
}
