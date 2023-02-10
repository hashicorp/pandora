using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.ManagedCassandras;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedCassandras";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CassandraClustersCreateUpdateOperation(),
        new CassandraClustersDeallocateOperation(),
        new CassandraClustersDeleteOperation(),
        new CassandraClustersGetOperation(),
        new CassandraClustersInvokeCommandOperation(),
        new CassandraClustersListByResourceGroupOperation(),
        new CassandraClustersListBySubscriptionOperation(),
        new CassandraClustersStartOperation(),
        new CassandraClustersStatusOperation(),
        new CassandraClustersUpdateOperation(),
        new CassandraDataCentersCreateUpdateOperation(),
        new CassandraDataCentersDeleteOperation(),
        new CassandraDataCentersGetOperation(),
        new CassandraDataCentersListOperation(),
        new CassandraDataCentersUpdateOperation(),
    };
}
