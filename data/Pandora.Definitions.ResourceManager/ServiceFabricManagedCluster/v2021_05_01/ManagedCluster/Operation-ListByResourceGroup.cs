using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster
{
    internal class ListByResourceGroupOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new ResourceGroupId();

        public override Type NestedItemType() => typeof(ManagedClusterModel);

        public override string? UriSuffix() => "/providers/Microsoft.ServiceFabric/managedClusters";


    }
}
