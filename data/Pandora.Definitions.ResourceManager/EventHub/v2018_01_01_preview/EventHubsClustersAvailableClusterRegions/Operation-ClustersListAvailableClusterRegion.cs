using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersAvailableClusterRegions
{
    internal class ClustersListAvailableClusterRegionOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ProviderId();

        public override Type? ResponseObject() => typeof(AvailableClustersListModel);

        public override string? UriSuffix() => "/availableClusterRegions";


    }
}
