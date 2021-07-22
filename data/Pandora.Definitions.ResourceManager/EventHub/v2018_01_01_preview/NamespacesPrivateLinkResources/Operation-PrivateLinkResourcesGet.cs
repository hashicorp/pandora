using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateLinkResources
{
    internal class PrivateLinkResourcesGet : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override object? ResponseObject()
        {
            return new PrivateLinkResourcesListResult();
        }

        public override string? UriSuffix()
        {
            return "/privateLinkResources";
        }
    }
}
