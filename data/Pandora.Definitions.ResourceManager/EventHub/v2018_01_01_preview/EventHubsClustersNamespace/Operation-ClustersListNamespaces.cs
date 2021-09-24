using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersNamespace
{
    internal class ClustersListNamespacesOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ClusterId();

        public override Type? ResponseObject() => typeof(EHNamespaceIdListResultModel);

        public override string? UriSuffix() => "/namespaces";


    }
}
