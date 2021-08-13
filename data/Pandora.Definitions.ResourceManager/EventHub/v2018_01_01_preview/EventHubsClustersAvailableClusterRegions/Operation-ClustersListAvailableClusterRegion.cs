using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersAvailableClusterRegions
{
    internal class ClustersListAvailableClusterRegionOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override Type? ResponseObject()
        {
            return typeof(AvailableClustersListModel);
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.EventHub/availableClusterRegions";
        }


    }
}
