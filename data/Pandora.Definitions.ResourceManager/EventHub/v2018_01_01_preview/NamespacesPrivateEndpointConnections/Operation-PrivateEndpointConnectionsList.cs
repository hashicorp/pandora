using Pandora.Definitions.Operations;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class PrivateEndpointConnectionsList : ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override object NestedItemType()
        {
            return new PrivateEndpointConnection();
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override string? UriSuffix()
        {
            return "/privateEndpointConnections";
        }
    }
}
