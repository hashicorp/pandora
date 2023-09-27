using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.ManagedCassandras;

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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationMethodConstant),
        typeof(ConnectionStateConstant),
        typeof(ManagedCassandraProvisioningStateConstant),
        typeof(NodeStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthenticationMethodLdapPropertiesModel),
        typeof(CassandraClusterPublicStatusModel),
        typeof(CassandraClusterPublicStatusDataCentersInlinedModel),
        typeof(CassandraClusterPublicStatusDataCentersInlinedNodesInlinedModel),
        typeof(CassandraErrorModel),
        typeof(CertificateModel),
        typeof(ClusterResourceModel),
        typeof(ClusterResourcePropertiesModel),
        typeof(CommandOutputModel),
        typeof(CommandPostBodyModel),
        typeof(ConnectionErrorModel),
        typeof(DataCenterResourceModel),
        typeof(DataCenterResourcePropertiesModel),
        typeof(ListClustersModel),
        typeof(ListDataCentersModel),
        typeof(ManagedCassandraReaperStatusModel),
        typeof(SeedNodeModel),
    };
}
