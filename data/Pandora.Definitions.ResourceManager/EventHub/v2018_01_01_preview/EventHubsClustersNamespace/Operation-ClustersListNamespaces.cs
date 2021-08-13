using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersNamespace
{
    internal class ClustersListNamespacesOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ClusterId();
        }

        public override Type? ResponseObject()
        {
            return typeof(EHNamespaceIdListResultModel);
        }

        public override string? UriSuffix()
        {
            return "/namespaces";
        }


    }
}
