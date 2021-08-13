using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
    internal class ClustersDeleteOperation : Operations.DeleteOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
            };
        }

        public override bool LongRunning()
        {
            return true;
        }

        public override ResourceID? ResourceId()
        {
            return new ClusterId();
        }


    }
}
