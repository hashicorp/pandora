using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.VirtualNetworkRules
{
    internal class NamespacesListVirtualNetworkRules : ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override object NestedItemType()
        {
            return new VirtualNetworkRule();
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override string? UriSuffix()
        {
            return "/virtualnetworkrules";
        }
    }
}
